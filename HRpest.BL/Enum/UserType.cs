using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum UserType
    {
        [Description("Applicant")]
        APPLICANT,
        [Description("HR Employee")]
        HR,
        [Description("Administrator")]
        ADMIN
    }
}
