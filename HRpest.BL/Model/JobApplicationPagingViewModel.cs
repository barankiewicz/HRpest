using System;
using System.Collections.Generic;
using System.Text;

namespace HRpest.BL.Model
{
    public class JobApplicationPagingViewModel
    {
        public IEnumerable<JobApplication> JobApplications { get; set; }
        public int TotalPage { get; set; }
    }
}
