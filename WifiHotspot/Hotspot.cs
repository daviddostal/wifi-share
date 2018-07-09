using EugenPechanec.NativeWifi;
using EugenPechanec.NativeWifi.Wlan;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WifiHotspot
{
    public class Hotspot : IHotspot
    {
        public string SsidName
        {
            get => _hostedNetwork.Ssid.Ssid;
            set => _hostedNetwork.Ssid = new Dot11Ssid(value);
        }
        public string Password
        {
            get => _hostedNetwork.SecondaryKey.Data.ToString();
            set => _hostedNetwork.SecondaryKey = new WlanHostedNetwork.Key(value, true);
        }
        public HotspotStatus Status => GetStatus();
        public int ClientCount => _hostedNetwork.Peers.Length;
        public bool IsSupported => _hostedNetwork.Enabled;

        public event EventHandler<HotspotStatus> StatusChanged;
        public event EventHandler<int> ClientsConnectedChanged;

        protected WlanHostedNetwork _hostedNetwork;
        protected SynchronizationContext _context;

        public Hotspot()
        {
            _context = SynchronizationContext.Current;
            WlanClient client = WlanClient.CreateClient();
            _hostedNetwork = client.HostedNetwork;
            _hostedNetwork.HnwkStateChange += (s, e) => OnStatusChanged();
            _hostedNetwork.HnwkRadioStateChange += (s, e) => OnStatusChanged();
            _hostedNetwork.HnwkPeerStateChange += (s, e) => OnClientCountChanged();
        }

        public async Task Start()
        {
            await Task.Run(async () =>
            {
                try { _hostedNetwork.Start(); }
                catch (Win32Exception ex) { await Task.FromException(new HotspotException("Couldn't start hosted network", ex)); }
            });
        }

        public async Task Stop()
        {
            await Task.Run(async () =>
            {
                try { _hostedNetwork.Stop(); }
                catch (Win32Exception ex) { await Task.FromException(new HotspotException("Couldn't stop hosted network", ex)); }
            });
        }

        protected virtual HotspotStatus GetStatus()
        {
            switch (_hostedNetwork.State)
            {
                case WlanHostedNetworkState.Unavailable:
                    return HotspotStatus.NotAvailable;
                case WlanHostedNetworkState.Idle:
                    return HotspotStatus.Stopped;
                case WlanHostedNetworkState.Active:
                    return HotspotStatus.Running;
                default:
                    return HotspotStatus.Unknown;
            }
        }

        protected virtual void OnStatusChanged()
            => _context.Send(new SendOrPostCallback((state)
                => StatusChanged?.Invoke(this, Status)), null);

        protected virtual void OnClientCountChanged()
            => _context.Send(new SendOrPostCallback((state)
                => ClientsConnectedChanged?.Invoke(this, ClientCount)), null);
    }
}
