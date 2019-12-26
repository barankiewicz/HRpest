using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum ApplicationStatus
    {
        [Display(Name = "No decision made yet")]
        NO_DECISION_MADE,
        [Display(Name = "Application approved!")]
        APPROVED,
        [Display(Name = "Application denied :(")]
        REJECTED
    }
}
