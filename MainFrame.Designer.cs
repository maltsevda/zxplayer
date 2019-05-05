namespace zxplayer
{
    partial class MainFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.foldersTree = new System.Windows.Forms.TreeView();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.filesList = new System.Windows.Forms.ListView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.play = new System.Windows.Forms.ToolStripButton();
            this.pause = new System.Windows.Forms.ToolStripButton();
            this.stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eject = new System.Windows.Forms.ToolStripButton();
            this.settings = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tape = new System.Windows.Forms.ToolStripStatusLabel();
            this.time = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.foldersTree);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filesList);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.splitContainer1.Size = new System.Drawing.Size(464, 234);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 3;
            // 
            // foldersTree
            // 
            this.foldersTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foldersTree.ImageIndex = 0;
            this.foldersTree.ImageList = this.iconsList;
            this.foldersTree.Location = new System.Drawing.Point(2, 0);
            this.foldersTree.Name = "foldersTree";
            this.foldersTree.SelectedImageIndex = 0;
            this.foldersTree.Size = new System.Drawing.Size(148, 234);
            this.foldersTree.TabIndex = 0;
            this.foldersTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnBeforeExpand);
            this.foldersTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelect);
            // 
            // iconsList
            // 
            this.iconsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconsList.ImageSize = new System.Drawing.Size(16, 16);
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // filesList
            // 
            this.filesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesList.HideSelection = false;
            this.filesList.Location = new System.Drawing.Point(0, 0);
            this.filesList.MultiSelect = false;
            this.filesList.Name = "filesList";
            this.filesList.Size = new System.Drawing.Size(308, 234);
            this.filesList.SmallImageList = this.iconsList;
            this.filesList.TabIndex = 0;
            this.filesList.UseCompatibleStateImageBehavior = false;
            this.filesList.View = System.Windows.Forms.View.List;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.play,
            this.pause,
            this.stop,
            this.toolStripSeparator1,
            this.eject,
            this.settings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(464, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // play
            // 
            this.play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.play.Image = global::zxplayer.Properties.Resources.icons8_play_16;
            this.play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 22);
            this.play.Text = "Play";
            this.play.Click += new System.EventHandler(this.OnPlay);
            // 
            // pause
            // 
            this.pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pause.Image = global::zxplayer.Properties.Resources.icons8_pause_16;
            this.pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(23, 22);
            this.pause.Text = "Pause";
            this.pause.Click += new System.EventHandler(this.OnPause);
            // 
            // stop
            // 
            this.stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stop.Image = global::zxplayer.Properties.Resources.icons8_stop_16;
            this.stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(23, 22);
            this.stop.Text = "Stop";
            this.stop.Click += new System.EventHandler(this.OnStop);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // eject
            // 
            this.eject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eject.Image = global::zxplayer.Properties.Resources.icons8_eject_16;
            this.eject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eject.Name = "eject";
            this.eject.Size = new System.Drawing.Size(23, 22);
            this.eject.Text = "External Player";
            this.eject.Click += new System.EventHandler(this.OnEject);
            // 
            // settings
            // 
            this.settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settings.Image = global::zxplayer.Properties.Resources.icons8_settings_16;
            this.settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(23, 22);
            this.settings.Text = "Settings";
            this.settings.Click += new System.EventHandler(this.OnSettings);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tape,
            this.time,
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 259);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(464, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tape
            // 
            this.tape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tape.Name = "tape";
            this.tape.Size = new System.Drawing.Size(287, 17);
            this.tape.Spring = true;
            this.tape.Text = "Stopped";
            this.tape.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // time
            // 
            this.time.AutoSize = false;
            this.time.Image = global::zxplayer.Properties.Resources.icons8_tape_16;
            this.time.Margin = new System.Windows.Forms.Padding(8, 3, 16, 2);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(91, 17);
            this.time.Text = " 0:00 / 0:00";
            // 
            // status
            // 
            this.status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.status.Image = global::zxplayer.Properties.Resources.icons8_ok_16;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(16, 17);
            this.status.Text = "Ok";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "MainFrame";
            this.Text = "ZX Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.Load += new System.EventHandler(this.OnLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView foldersTree;
        private System.Windows.Forms.ListView filesList;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton play;
        private System.Windows.Forms.ToolStripButton pause;
        private System.Windows.Forms.ToolStripButton stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton eject;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tape;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripButton settings;
        private System.Windows.Forms.ToolStripStatusLabel time;
    }
}

