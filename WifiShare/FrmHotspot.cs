using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CliWrap;
using CliWrap.Models;
using CliWrap.Exceptions;
using CliWrap.Services;
using System.Diagnostics;

namespace WifiShare
{
    public partial class FrmHotspot : Form
    {
        public FrmHotspot()
        {
            InitializeComponent();
            HotspotInformation();
            updateClientsTimer.Start();
        }

        private async void HotspotInformation()
        {
            using (Cli cli = new Cli("netsh.exe"))
            {
                string infoCommand = "wlan show hostednetwork";
                ExecutionOutput infoResult = await cli.ExecuteAsync(new ExecutionInput(infoCommand));
                Dictionary<string, string> hotspotInfo = ParseSettings(infoResult.StandardOutput);
                hotspotNameTbx.Text = hotspotInfo["SSID name"];

                string securityInfoCommand = "wlan show hostednetwork setting=security";
                ExecutionOutput securityInfoResult = await cli.ExecuteAsync(new ExecutionInput(securityInfoCommand));

                Dictionary<string, string> securityInfo = ParseSettings(securityInfoResult.StandardOutput);
                hotspotPasswordTbx.Text = securityInfo["User security key"];

                if (hotspotInfo["Status"] == "Started")
                {
                }
            }
        }

        private Dictionary<string, string> ParseSettings(string settings)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string[] rows = settings.Trim().Split('\n');
            IEnumerable<string> commands = rows.Skip(3).Select((row) => row.Trim());
            foreach (string commandStr in commands)
            {
                if (!commandStr.Contains(':'))
                    continue;
                IEnumerable<string> parts = commandStr.Split(':').Select((str) => str.Trim());
                string name = parts.ElementAt(0);
                string value = parts.ElementAt(1).Trim('"');
                values.Add(name, value);
            }
            return values;
        }

        private async void startHotspotBtn_Click(object sender, EventArgs e)
        {
            string hotspotName = hotspotNameTbx.Text;
            string hotspotPassword = hotspotPasswordTbx.Text;
            using (Cli cli = new Cli("netsh.exe"))
            {
                updateClientsTimer.Stop();
                statusTsL.Text = "Status: starting...";
                string setCommand = $"wlan set hostednetwork mode=allow ssid=\"{hotspotName}\" key=\"{hotspotPassword}\"";
                ExecutionOutput setResult = await cli.ExecuteAsync(new ExecutionInput(setCommand));

                ExecutionOutput startResult = await cli.ExecuteAsync(new ExecutionInput("wlan start hostednetwork"));

                if (startResult.StandardOutput.StartsWith("The hosted network started."))
                {
                    startHotspotBtn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The hotspot couldn't start. Please check your Wifi settings.", "Error starting hotspot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                updateClientsTimer.Start();
            }
        }

        private async void stopHotspotBtn_Click(object sender, EventArgs e)
        {
            using (Cli cli = new Cli("netsh.exe"))
            {
                statusTsL.Text = "Status: stopping...";
                string stopCommand = "wlan stop hostednetwork";
                ExecutionOutput stopResult = await cli.ExecuteAsync(new ExecutionInput(stopCommand));
                stopHotspotBtn.Enabled = false;
            }
        }

        private async void updateClientsTimer_Tick(object sender, EventArgs e)
        {
            using (Cli cli = new Cli("netsh.exe"))
            {
                string infoCommand = "wlan show hostednetwork";
                ExecutionOutput infoResult = await cli.ExecuteAsync(new ExecutionInput(infoCommand));
                Dictionary<string, string> hotspotInfo = ParseSettings(infoResult.StandardOutput);
                if (hotspotInfo.ContainsKey("Number of clients"))
                    clientsTsL.Text = $"Clients: {hotspotInfo["Number of clients"]}";
                statusTsL.Text = $"Status: {hotspotInfo["Status"].ToLower()}";
                if (hotspotInfo["Status"] != "Started")
                {
                    stopHotspotBtn.Enabled = false;
                    startHotspotBtn.Enabled = true;
                }
                else
                {
                    stopHotspotBtn.Enabled = true;
                    startHotspotBtn.Enabled = false;
                }
            }
        }
    }
}
