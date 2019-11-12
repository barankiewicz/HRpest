using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HRpest.BL.Enum
{
    public enum ApplicationStatus
    {
        [Description("No decision made yet")]
        NO_DECISION_MADE,
        [Description("Application approved!")]
        APPROVED,
        [Description("Application denied :(")]
        REJECTED
    }
}
