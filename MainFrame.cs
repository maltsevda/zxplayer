// Copyright (c) 2019 Denis Maltsev. All Rights Reserved.

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace zxplayer
{
    public partial class MainFrame : Form
    {
        private const int defaultSampleRate = 44100;

        public string root_path = "";
        public string audacity_path = "";
        public int sampleRate = defaultSampleRate;

        private string tape2wav_path = @"\fuse-utils\tape2wav.exe";
        private string cache_path = @"\cache\";
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        private AudioPlayer player = new AudioPlayer();
        private string playing_file = "";

        public MainFrame()
        {
            InitializeComponent();

            string path = Directory.GetCurrentDirectory();
            tape2wav_path = path + tape2wav_path;
            cache_path = path + cache_path;

            Application.Idle += new EventHandler(OnIdle);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (!File.Exists(tape2wav_path))
            {
                MessageBox.Show("tape2wav.exe not found!", "Error!");
                Close();
                return;
            }
            if (!Directory.Exists(cache_path))
                Directory.CreateDirectory(cache_path);

            root_path = Properties.Settings.Default.RootFolder;
            audacity_path = Properties.Settings.Default.AudacityPath;

            if (UpdateSettingsIcon())
                OnSettings(this, EventArgs.Empty);
            else
                FillTreeSafe();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.RootFolder = root_path;
            Properties.Settings.Default.AudacityPath = audacity_path;
            Properties.Settings.Default.Save();

            // clear cache
            foreach (var entry in cache)
                File.Delete(entry.Value);
        }

        private void OnIdle(object sender, EventArgs e)
        {
            play.Enabled = filesList.SelectedItems.Count > 0;
            pause.Enabled = player.Playing;
            stop.Enabled = player.Playing;
            eject.Enabled = (filesList.SelectedItems.Count > 0) && (audacity_path.Length > 0);
        }

        private void OnSettings(object sender, EventArgs e)
        {
            SettingsFrame dlg = new SettingsFrame();
            dlg.rootFolder.Text = root_path;
            dlg.externalPlayer.Text = audacity_path;
            dlg.sampleRate.Text = sampleRate.ToString();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                root_path = dlg.rootFolder.Text;
                audacity_path = dlg.externalPlayer.Text;
                if (!int.TryParse(dlg.sampleRate.Text, out sampleRate))
                    sampleRate = defaultSampleRate;
            }
            UpdateSettingsIcon();
            FillTreeSafe();
        }

        //
        // Player
        //

        private string GetWAV(string in_path)
        {
            if (cache.ContainsKey(in_path))
            {
                return cache[in_path];
            }
            else
            {
                string out_name = Path.GetRandomFileName();
                out_name = Path.ChangeExtension(out_name, "wav");
                string out_path = cache_path + out_name;

                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = tape2wav_path;
                p.StartInfo.Arguments = string.Format("-r {0} \"{1}\" \"{2}\"", sampleRate, in_path, out_path);
                p.Start();

                if (p.WaitForExit(5000) == true)
                {
                    if (p.ExitCode == 0)
                    {
                        cache[in_path] = out_path;
                        return out_path;
                    }
                }
            }
            return "";
        }

        private void OnPlay(object sender, EventArgs e)
        {
            player.Stop();

            if (filesList.SelectedItems.Count > 0)
            {
                string in_path = filesList.SelectedItems[0].Tag.ToString();
                string out_path = GetWAV(in_path);
                if (out_path.Length > 0)
                {
                    player.Play(out_path);
                    playing_file = Path.GetFileNameWithoutExtension(in_path);
                }
            }
        }

        private void OnPause(object sender, EventArgs e)
        {
            // check Paused first!
            if (player.Paused)
                player.Resume();
            else if (player.Playing)
                player.Pause();
        }

        private void OnStop(object sender, EventArgs e)
        {
            player.Stop();
            playing_file = "";
        }

        private void OnEject(object sender, EventArgs e)
        {
            OnStop(sender, e);

            if (audacity_path.Length == 0)
                return;
            string in_path = filesList.SelectedItems[0].Tag.ToString();
            string out_path = GetWAV(in_path);
            if (out_path.Length == 0)
                return;
            Process.Start(audacity_path, out_path);
        }

        private void OnTimer(object sender, EventArgs e)
        {
            if (pause.Enabled)
            {
                string elapsed = FormatTime(player.Elapsed);
                string duration = FormatTime(player.Duration);
                tape.Text = "Playing: " + playing_file;
                time.Text = $" {elapsed} / {duration}";
            }
            else if (stop.Enabled)
                tape.Text = "Paused: " + playing_file;
            else
            {
                tape.Text = "Stopped";
                time.Text = " 0:00 / 0:00";
            }
        }

        //
        // Norton Commander
        //

        private void OnBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foldersTree.BeginUpdate();
            FillTreeNode(e.Node.Nodes, e.Node.Tag.ToString());
            foldersTree.EndUpdate();
        }

        private void OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            filesList.BeginUpdate();
            FillListItems(filesList.Items, e.Node.Tag.ToString());
            filesList.EndUpdate();
        }

        private void FillTreeSafe()
        {
            if (Directory.Exists(root_path))
            {
                foldersTree.BeginUpdate();
                foldersTree.Nodes.Clear();
                FillTreeNode(foldersTree.Nodes, root_path);
                foldersTree.EndUpdate();
            }
        }

        //
        // Directories Tree & Files List
        //

        private void FillTreeNode(TreeNodeCollection nodes, string path)
        {
            if (nodes.Count == 1 && nodes[0].Text == "")
                nodes.Clear();
            if (nodes.Count > 0)
                return;

            try
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (DirectoryInfo dir in root.GetDirectories())
                {
                    TreeNode item = nodes.Add(dir.FullName + '\\', dir.Name);
                    ShellFileInfo finfo = new ShellFileInfo(dir.FullName);
                    string key = finfo.IconIndex().ToString();

                    if (!iconsList.Images.ContainsKey(key))
                        iconsList.Images.Add(key, finfo.FileIcon());

                    item.Tag = dir.FullName;
                    item.Text = finfo.FileName();
                    item.ImageKey = key;
                    item.SelectedImageKey = key;
                    item.Nodes.Add("");
                }
            }
            catch { }
        }

        private void FillListItems(ListView.ListViewItemCollection items, string path)
        {
            items.Clear();

            try
            {
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (FileInfo file in root.GetFiles())
                {
                    ShellFileInfo finfo = new ShellFileInfo(file.FullName);
                    string[] strs = { file.Name, Convert.ToString(file.Length / 1024) + "KB", finfo.FileType() };
                    ListViewItem item = new ListViewItem(strs);
                    string key = finfo.IconIndex().ToString();

                    if (!iconsList.Images.ContainsKey(key))
                        iconsList.Images.Add(key, finfo.FileIcon());

                    item.ImageKey = key;
                    item.Tag = file.FullName;
                    items.Add(item);
                }
            }
            catch { }
        }

        private string FormatTime(long milliseconds)
        {
            long seconds = milliseconds / 1000;
            long minutes = seconds / 60;
            seconds -= minutes * 60;
            return $"{minutes}:{seconds:d2}";
        }

        private bool UpdateSettingsIcon()
        {
            if (!Directory.Exists(root_path))
            {
                status.Image = Properties.Resources.icons8_error_16;
                status.ToolTipText = "Root Folder not found!";
                return true;
            }
            else if (!File.Exists(audacity_path))
            {
                status.Image = Properties.Resources.icons8_warning_16;
                status.ToolTipText = "External player not found!";
            }
            else
            {
                status.Image = Properties.Resources.icons8_ok_16;
                status.ToolTipText = "All fine.";
            }
            return false;
        }
    }
}
