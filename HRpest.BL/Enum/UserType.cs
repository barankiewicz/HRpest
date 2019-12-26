using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum UserType
    {
        [Display(Name = "Applicant")]
        APPLICANT,
        [Display(Name = "HR Employee")]
        HR,
        [Display(Name = "Administrator")]
        ADMIN
    }
}
