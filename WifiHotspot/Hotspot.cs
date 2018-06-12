using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Services;
using CliWrap.Models;
using CliWrap.Exceptions;
using System.Timers;

namespace WifiHotspot
{
    public class Hotspot : IDisposable
    {
        public string SsidName { get; set; } = "";
        public string Password { get; set; } = "";
        public HotspotStatus Status { get; protected set; } = HotspotStatus.Initializing;
        public event EventHandler<HotspotStatusEventArgs> StatusChanged;

        protected Cli cli;
        protected readonly Dictionary<string, HotspotStatus> statusMapping = new Dictionary<string, HotspotStatus>
        {
            {"Not started",    HotspotStatus.Stopped},
            {"Started",        HotspotStatus.Running},
            {"Not available",  HotspotStatus.NotAvailable}
        };

        public Hotspot()
        {
            cli = new Cli("netsh");
        }

        public async Task Initialize()
        {
            ChangeStatus(HotspotStatus.Initializing);

            ExecutionOutput infoOutput = await cli.ExecuteAsync("wlan show hostednetwork");
            Dictionary<string, string> hotspotInfo = ParseSettings(infoOutput.StandardOutput);
            if (hotspotInfo.ContainsKey("SSID name"))
                SsidName = hotspotInfo["SSID name"];

            ExecutionOutput securityOutput = await cli.ExecuteAsync("wlan show hostednetwork setting=security");
            Dictionary<string, string> securityInfo = ParseSettings(securityOutput.StandardOutput);
            if (securityInfo.ContainsKey("User security key"))
                Password = securityInfo["User security key"];

            UpdateStatus();
        }

        public async Task Start()
        {
            Setup();
            ChangeStatus(HotspotStatus.Starting);
            ExecutionOutput output = await cli.ExecuteAsync("wlan start hostednetwork");
            UpdateStatus();
        }

        protected async virtual void Setup()
        {
            ChangeStatus(HotspotStatus.CreatingHotspot);
            string command = $"wlan set hostednetwork mode=allow ssid=\"{SsidName}\" key=\"{Password}\"";
            ExecutionOutput output = await cli.ExecuteAsync(command);
            UpdateStatus();
        }

        public async Task Stop()
        {
            ChangeStatus(HotspotStatus.Stopping);
            ExecutionOutput output = await cli.ExecuteAsync("wlan stop hostednetwork");
            UpdateStatus();
        }

        public bool IsSupported()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, string> ParseSettings(string settings)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string[] rows = settings.Trim().Split('\n');
            IEnumerable<string> commands = rows.Select((row) => row.Trim());
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

        public async Task CheckConnection()
        {
            HotspotStatus status = await GetStatus();
            if (this.Status == HotspotStatus.NotAvailable && status != HotspotStatus.NotAvailable)
                ChangeStatus(status);
            if (status == HotspotStatus.NotAvailable && this.Status != HotspotStatus.NotAvailable)
                ChangeStatus(status);
        }

        protected async virtual void UpdateStatus()
        {
            HotspotStatus status = await GetStatus();
            if (Status != status)
                ChangeStatus(status);
        }

        protected async virtual Task<HotspotStatus> GetStatus()
        {
            ExecutionOutput infoResult = await cli.ExecuteAsync("wlan show hostednetwork");
            Dictionary<string, string> hotspotInfo = ParseSettings(infoResult.StandardOutput);
            string name = hotspotInfo["Status"];
            HotspotStatus status = HotspotStatus.Unknown;
            if (statusMapping.ContainsKey(name))
                status = statusMapping[name];
            return status;
        }

        protected virtual void ChangeStatus(HotspotStatus newStatus)
        {
            Status = newStatus;
            StatusChanged?.Invoke(this, new HotspotStatusEventArgs(newStatus));
        }

        public void Dispose()
        {
            cli.Dispose();
        }

        public class HotspotStatusEventArgs : EventArgs
        {
            public HotspotStatus Status { get; protected set; }
            public HotspotStatusEventArgs(HotspotStatus status)
            {
                Status = status;
            }
        }
    }
}
