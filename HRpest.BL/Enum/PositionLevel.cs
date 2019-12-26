using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum PositionLevel
    {
        [Display(Name = "Entry level")]
        ENTRY_LEVEL,
        [Display(Name = "Internship")]
        INTERNSHIP,
        [Display(Name = "Junior")]
        JUNIOR,
        [Display(Name = "Mid")]
        MID,
        [Display(Name = "Senior")]
        SENIOR
    }
}
