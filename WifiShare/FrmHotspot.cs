using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WifiHotspot;

namespace WifiShare
{
    public partial class FrmHotspot : Form
    {
        private Hotspot hotspot;
        public FrmHotspot()
        {
            InitializeComponent();
            Initialize();
        }

        private async void Initialize()
        {
            hotspot = new Hotspot();
            hotspot.StatusChanged += Hotspot_StatusChanged;
            await hotspot.Initialize();
            hotspotNameTbx.Text = hotspot.SsidName;
            hotspotPasswordTbx.Text = hotspot.Password;
            updateClientsTimer.Start();
        }

        private void Hotspot_StatusChanged(object sender, Hotspot.HotspotStatusEventArgs e)
        {
            statusTsL.Text = $"Status: {e.Status.GetDescription().ToLower()}";
            stopHotspotBtn.Enabled = e.Status == HotspotStatus.Running;
            startHotspotBtn.Enabled = e.Status == HotspotStatus.Stopped;
        }

        private async void startHotspotBtn_Click(object sender, EventArgs e)
        {
            hotspot.SsidName = hotspotNameTbx.Text;
            hotspot.Password = hotspotPasswordTbx.Text;
            await hotspot.Start();
        }

        private async void stopHotspotBtn_Click(object sender, EventArgs e)
        {
            await hotspot.Stop();
        }

        private async void updateClientsTimer_Tick(object sender, EventArgs e)
        {
            await hotspot.CheckConnection();
        }
    }
}
