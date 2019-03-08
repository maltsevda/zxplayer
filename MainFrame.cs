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
        private string tape2wav_path = @"\fuse-utils\tape2wav.exe";
        private string cache_path = @"\cache\";
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        private AudioPlayer player = new AudioPlayer();

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

            rootFolder.Text = Properties.Settings.Default.RootFolder;
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.RootFolder = rootFolder.Text;
            Properties.Settings.Default.Save();

            // clear cache
            foreach (var entry in cache)
                File.Delete(entry.Value);
        }

        private void OnIdle(object sender, EventArgs e)
        {
            play.Enabled = filesList.SelectedItems.Count > 0;
            pause.Enabled = player.Playing && !player.Paused;
            stop.Enabled = player.Playing;
        }

        //
        // Player
        //

        private void OnPlay(object sender, EventArgs e)
        {
            if (player.Paused)
            {
                player.Resume();
                return;
            }

            if (filesList.SelectedItems.Count > 0)
            {
                string in_path = filesList.SelectedItems[0].Tag.ToString();
                string out_path;
                bool allow_start = false;

                if (cache.ContainsKey(in_path))
                {
                    out_path = cache[in_path];
                    allow_start = true;
                }
                else
                {
                    string out_name = Path.GetRandomFileName();
                    out_name = Path.ChangeExtension(out_name, "wav");
                    out_path = cache_path + out_name;
                    int rate = 44100;
                    if (!int.TryParse(sampleRate.Text, out rate))
                    {
                        rate = 44100;
                        sampleRate.Text = rate.ToString();
                    }

                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = tape2wav_path;
                    p.StartInfo.Arguments = string.Format("-r {0} \"{1}\" \"{2}\"", rate, in_path, out_path);
                    p.Start();

                    if (p.WaitForExit(5000) == true)
                    {
                        if (p.ExitCode == 0)
                        {
                            cache[in_path] = out_path;
                            allow_start = true;
                        }
                    }
                }

                if (allow_start)
                    player.Play(out_path);
            }
        }

        private void OnPause(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void OnStop(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            if (pause.Enabled)
            {
                string elapsed = FormatTime(player.Elapsed);
                string duration = FormatTime(player.Duration);
                status.Text = $"{elapsed} / {duration}";
            }
            else if (!stop.Enabled)
            {
                status.Text = "Stopped";
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

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(rootFolder.Text))
            {
                foldersTree.BeginUpdate();
                foldersTree.Nodes.Clear();
                FillTreeNode(foldersTree.Nodes, rootFolder.Text);
                foldersTree.EndUpdate();
            }
        }

        private void OnBrowseForFolder(object sender, EventArgs e)
        {
            if (foldersDlg.ShowDialog() == DialogResult.OK)
                rootFolder.Text = foldersDlg.SelectedPath;
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
    }
}
