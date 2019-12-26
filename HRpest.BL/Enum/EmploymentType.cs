using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum EmploymentType
    {
        [Display(Name = "Bussiness-2-Bussiness")]
        B2B,
        [Display(Name = "Umowa o Dzieło")]
        UOD,
        [Display(Name = "Umowa Zlecenie")]
        UOZ,
        [Display(Name = "Umowa o Pracę")]
        UOP,
        [Display(Name = "Inna")]
        OTHER
    }
}
