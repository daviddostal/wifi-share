using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiShare
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
            => InitializeComponent();

        private void OkButtonClick(object sender, EventArgs e)
            => DialogResult = DialogResult.OK;

        private void GithubLinkLabelClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/daviddostal/wifi-share");
            githubLinkLabel.LinkVisited = true;
        }

        private void licenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/daviddostal/wifi-share/blob/master/LICENSE");
            licenseLinkLabel.LinkVisited = true;
        }
    }
}
