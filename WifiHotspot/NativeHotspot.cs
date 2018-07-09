using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EugenPechanec.NativeWifi.Wlan;

namespace WifiHotspot
{
    public class NativeHotspot : IHotspot
    {
        public string SsidName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HotspotStatus Status => throw new NotImplementedException();
        public int ClientsConnected => throw new NotImplementedException();
        public bool IsSupported => throw new NotImplementedException();

        public event EventHandler<HotspotStatus> StatusChanged;
        public event EventHandler<int> ClientsConnectedChanged;

        protected WlanHostedNetwork _hostedNetwork;

        public NativeHotspot()
        {
            WlanClient client = WlanClient.CreateClient();
            _hostedNetwork = client.HostedNetwork;
        }

        public Task Start()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
