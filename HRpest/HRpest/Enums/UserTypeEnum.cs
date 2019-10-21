using System.ComponentModel;

namespace HRpest.Enums
{
    public static class UserTypeEnumExtensions
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
    public enum UserTypeEnum
    {
        [Description("Administrator")]
        ADMIN,
        [Description("Applicant")]
        APPLICANT,
        [Description("HR Employee")]
        HR
    }
}
