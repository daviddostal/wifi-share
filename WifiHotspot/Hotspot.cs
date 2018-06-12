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
        public int ClientsConnected { get; protected set; } = 0;
        public event EventHandler<HotspotStatus> StatusChanged;
        public event EventHandler<int> ClientsConnectedChanged;

        protected Cli cli;
        protected Dictionary<string, string> properties = new Dictionary<string, string>();
        protected Dictionary<string, string> securityProperties = new Dictionary<string, string>();

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

            await UpdateProperties();
            if (properties.ContainsKey("SSID name"))
                SsidName = properties["SSID name"];

            await UpdateSecurityProperties();
            if (securityProperties.ContainsKey("User security key"))
                Password = securityProperties["User security key"];

            UpdateStatus();
            UpdateNumberOfClients();
        }

        protected async virtual Task UpdateProperties()
        {
            ExecutionOutput infoOutput = await cli.ExecuteAsync("wlan show hostednetwork");
            properties = ParseSettings(infoOutput.StandardOutput);
        }

        protected async virtual Task UpdateSecurityProperties()
        {
            ExecutionOutput securityOutput = await cli.ExecuteAsync("wlan show hostednetwork setting=security");
            securityProperties = ParseSettings(securityOutput.StandardOutput);
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
            await UpdateProperties();
            HotspotStatus status = GetStatus();
            if (this.Status == HotspotStatus.NotAvailable || status == HotspotStatus.NotAvailable)
                ChangeStatus(status);
            UpdateNumberOfClients();
        }

        protected virtual void UpdateNumberOfClients()
        {
            if (properties.ContainsKey("Number of clients"))
            {
                int clientsConnected = int.Parse(properties["Number of clients"].Trim());
                ChangeClientsConnected(clientsConnected);
            }
            else
                ChangeClientsConnected(0);
        }

        protected async virtual void UpdateStatus()
        {
            await UpdateProperties();
            HotspotStatus status = GetStatus();
            ChangeStatus(status);
        }

        protected virtual HotspotStatus GetStatus()
        {
            string name = properties["Status"];
            HotspotStatus status = HotspotStatus.Unknown;
            if (statusMapping.ContainsKey(name))
                status = statusMapping[name];
            return status;
        }

        protected virtual void ChangeStatus(HotspotStatus newStatus)
        {
            if (Status != newStatus)
            {
                Status = newStatus;
                StatusChanged?.Invoke(this, newStatus);
            }
        }

        protected virtual void ChangeClientsConnected(int clients)
        {
            if (ClientsConnected != clients)
            {
                ClientsConnected = clients;
                ClientsConnectedChanged?.Invoke(this, clients);
            }
        }

        public void Dispose()
        {
            cli.Dispose();
        }
    }
}
