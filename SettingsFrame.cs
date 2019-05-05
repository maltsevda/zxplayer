using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zxplayer
{
    public partial class SettingsFrame : Form
    {
        public SettingsFrame()
        {
            InitializeComponent();
        }

        private void OnRootFolderBrowse(object sender, EventArgs e)
        {
            if (folderDlg.ShowDialog(this) == DialogResult.OK)
                rootFolder.Text = folderDlg.SelectedPath;
        }

        private void OnExternalPlayerBrowse(object sender, EventArgs e)
        {
            if (fileDlg.ShowDialog(this) == DialogResult.OK)
                externalPlayer.Text = fileDlg.FileName;
        }
    }
}
