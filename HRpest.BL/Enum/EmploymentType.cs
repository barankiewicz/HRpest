using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum EmploymentType
    {
        [Description("Bussiness-2-Bussiness")]
        B2B,
        [Description("Umowa o Dzieło")]
        UOD,
        [Description("Umowa Zlecenie")]
        UOZ,
        [Description("Umowa o Pracę")]
        UOP
    }
}
