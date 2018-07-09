using System;
using System.Threading.Tasks;

namespace WifiHotspot
{
    public interface IHotspot
    {
        string SsidName { get; set; }
        string Password { get; set; }
        HotspotStatus Status { get; }
        int ClientsConnected { get; }
        bool IsSupported { get; }

        event EventHandler<HotspotStatus> StatusChanged;
        event EventHandler<int> ClientsConnectedChanged;

        Task Initialize();
        Task Start();
        Task Stop();
    }
}
