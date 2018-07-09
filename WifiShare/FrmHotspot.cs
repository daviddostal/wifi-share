using System;
using System.Windows.Forms;
using WifiHotspot;
using System.ComponentModel;

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
            _hotspot.StatusChanged += (s, e) => UpdateStatus();
            _hotspot.ClientsConnectedChanged += (s, e) => UpdateClientCount();
            hotspotNameTbx.Text = _hotspot.SsidName;
            hotspotPasswordTbx.Text = _hotspot.Password;
            UpdateStatus();
        }

        private void UpdateClientCount()
            => clientsTsL.Text = $"Clients: {_hotspot.ClientCount}";

        private void UpdateStatus()
        {
            statusTsL.Text = $"Status: {_hotspot.Status.GetDescription().ToLower()}";
            stopHotspotBtn.Enabled = _hotspot.Status == HotspotStatus.Running;
            startHotspotBtn.Enabled = _hotspot.Status == HotspotStatus.Stopped;
        }

        private async void StartHotspotBtn_Click(object sender, EventArgs e)
        {
            _hotspot.SsidName = hotspotNameTbx.Text;
            _hotspot.Password = hotspotPasswordTbx.Text;
            try { await _hotspot.Start(); }
            catch(HotspotException) { MessageBox.Show(this, "Couldn't succesfully start the hotspot.", "Error starting hotspot", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void StopHotspotBtn_Click(object sender, EventArgs e)
        {
            try { await _hotspot.Stop(); }
            catch(HotspotException) { MessageBox.Show(this, "Couldn't succesfully stop the hotspot.", "Error stopping hotspot", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FrmHotspot_HelpButtonClicked(object sender, CancelEventArgs e)
        { 
            new AboutDialog().ShowDialog(this);
            e.Cancel = true;
        }
    }
}
