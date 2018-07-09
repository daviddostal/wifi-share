using System;
using System.Runtime.Serialization;

namespace WifiHotspot
{
    public class HotspotException : InvalidOperationException
    {
        public HotspotException() : base() { }
        public HotspotException(string message) : base(message) { }
        public HotspotException(string message, Exception innerException) : base(message, innerException) { }
        protected HotspotException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
