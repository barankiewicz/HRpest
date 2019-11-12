using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum PositionLevel
    {
        [Description("Entry level")]
        ENTRY_LEVEL,
        [Description("Internship")]
        INTERNSHIP,
        [Description("Junior")]
        JUNIOR,
        [Description("Mid")]
        MID,
        [Description("Senior")]
        SENIOR
    }
}
