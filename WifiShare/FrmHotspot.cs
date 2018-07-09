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
using static WifiShare.Utilities.StringUtils;

namespace WifiShare
{
    public partial class FrmHotspot : Form
    {
        private IHotspot _hotspot;

        public FrmHotspot()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _hotspot = new Hotspot();
            if (!_hotspot.IsSupported)
            {
                MessageBox.Show(this, $"Wireless hotspots are not supported by your system or network card.", "Not supported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Load += (s, e) => Close();
            }
            _hotspot.StatusChanged += Hotspot_StatusChanged;
            _hotspot.ClientsConnectedChanged += Hotspot_ClientsConnectedChanged;
            hotspotNameTbx.Text = _hotspot.SsidName;
            hotspotPasswordTbx.Text = _hotspot.Password;
        }

        private void Hotspot_ClientsConnectedChanged(object sender, int clients)
        {
            clientsTsL.Text = $"Clients: {clients}";
        }

        private void Hotspot_StatusChanged(object sender, HotspotStatus newStatus)
        {
            statusTsL.Text = $"Status: {newStatus.GetDescription().ToLower()}";
            stopHotspotBtn.Enabled = newStatus == HotspotStatus.Running;
            startHotspotBtn.Enabled = newStatus == HotspotStatus.Stopped;
        }

        private async void StartHotspotBtn_Click(object sender, EventArgs e)
        {
            _hotspot.SsidName = hotspotNameTbx.Text;
            _hotspot.Password = hotspotPasswordTbx.Text;
            await _hotspot.Start();
        }

        private async void StopHotspotBtn_Click(object sender, EventArgs e)
        {
            await _hotspot.Stop();
        }
    }
}
