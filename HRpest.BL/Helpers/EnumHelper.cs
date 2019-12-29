using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace HRpest.BL.Helpers
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
