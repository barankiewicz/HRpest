using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HRpest.Enums
{
    public static class EmploymentTypeEnumExtensions
    {
        public static string ToDescriptionString(this EmploymentTypeEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
    public enum EmploymentTypeEnum
    {
        [Description("B2B")]
        B2B,
        [Description("Umowa Zlecenie")]
        UOZ,
        [Description("Umowa o Pracę")]
        UOP,
        [Description("Umowa o Dzieło")]
        UOD
    }
}
