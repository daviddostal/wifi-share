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

    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T value) where T : struct
        {
            if (!value.GetType().IsEnum)
                throw new ArgumentException("Value must be of type enum.");

            MemberInfo[] memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return value.ToString();
        }
    }
}
