using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WifiHotspot
{
    public enum HotspotStatus
    {
        [Description("Running")]
        Running,

        [Description("Stopped")]
        Stopped,

        [Description("Not available")]
        NotAvailable,

        [Description("Unknown")]
        Unknown,
    }
}
