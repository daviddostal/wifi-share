using System;
using System.Windows.Forms;
using WifiHotspot;

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
            => clientsTsL.Text = $"Clients: {clients}";

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
            try { await _hotspot.Start(); }
            catch(HotspotException) { MessageBox.Show(this, "Couldn't succesfully start the hotspot.", "Error starting hotspot", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void StopHotspotBtn_Click(object sender, EventArgs e)
        {
            try { await _hotspot.Stop(); }
            catch(HotspotException) { MessageBox.Show(this, "Couldn't succesfully stop the hotspot.", "Error stopping hotspot", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
