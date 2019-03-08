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
            this.label1 = new System.Windows.Forms.Label();
            this.rootFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.foldersTree = new System.Windows.Forms.TreeView();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.filesList = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.sampleRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.foldersDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Folder:";
            // 
            // rootFolder
            // 
            this.rootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootFolder.Location = new System.Drawing.Point(81, 14);
            this.rootFolder.Name = "rootFolder";
            this.rootFolder.Size = new System.Drawing.Size(319, 20);
            this.rootFolder.TabIndex = 1;
            this.rootFolder.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(406, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnBrowseForFolder);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(15, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.foldersTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filesList);
            this.splitContainer1.Size = new System.Drawing.Size(437, 174);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 3;
            // 
            // foldersTree
            // 
            this.foldersTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foldersTree.ImageIndex = 0;
            this.foldersTree.ImageList = this.iconsList;
            this.foldersTree.Location = new System.Drawing.Point(0, 0);
            this.foldersTree.Name = "foldersTree";
            this.foldersTree.SelectedImageIndex = 0;
            this.foldersTree.Size = new System.Drawing.Size(142, 174);
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
            this.filesList.Size = new System.Drawing.Size(291, 174);
            this.filesList.SmallImageList = this.iconsList;
            this.filesList.TabIndex = 0;
            this.filesList.UseCompatibleStateImageBehavior = false;
            this.filesList.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sample Rate:";
            // 
            // sampleRate
            // 
            this.sampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sampleRate.Location = new System.Drawing.Point(89, 249);
            this.sampleRate.MaxLength = 10;
            this.sampleRate.Name = "sampleRate";
            this.sampleRate.Size = new System.Drawing.Size(56, 20);
            this.sampleRate.TabIndex = 5;
            this.sampleRate.Text = "44100";
            this.sampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hz";
            // 
            // pause
            // 
            this.pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pause.Enabled = false;
            this.pause.Image = global::zxplayer.Properties.Resources.icons8_pause_21;
            this.pause.Location = new System.Drawing.Point(354, 246);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(46, 23);
            this.pause.TabIndex = 9;
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.OnPause);
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Enabled = false;
            this.stop.Image = global::zxplayer.Properties.Resources.icons8_stop_21;
            this.stop.Location = new System.Drawing.Point(406, 246);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(46, 23);
            this.stop.TabIndex = 8;
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.OnStop);
            // 
            // play
            // 
            this.play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.play.Image = global::zxplayer.Properties.Resources.icons8_play_21;
            this.play.Location = new System.Drawing.Point(302, 246);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(46, 23);
            this.play.TabIndex = 7;
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.OnPlay);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.status.Location = new System.Drawing.Point(15, 220);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(437, 18);
            this.status.TabIndex = 11;
            this.status.Text = "00:00 / 00:00";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // foldersDlg
            // 
            this.foldersDlg.ShowNewFolderButton = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.status);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.play);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sampleRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rootFolder);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "MainFrame";
            this.Text = "ZX Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.Load += new System.EventHandler(this.OnLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rootFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView foldersTree;
        private System.Windows.Forms.ListView filesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sampleRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.FolderBrowserDialog foldersDlg;
        private System.Windows.Forms.Timer timer;
    }
}

