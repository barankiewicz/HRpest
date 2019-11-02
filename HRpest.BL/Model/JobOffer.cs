using HRpest.BL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRpest.BL.Model
{
    public class JobOffer
    {
        public int Id { get; set; }
        public User CreatedBy { get; set; }

        public EmploymentType EmploymentType { get; set; }
        public PositionLevel PositionLevel { get; set; }
        public int HoursWeekly { get; set; }
        public int RemoteHoursWeekly { get; set; }
        public int MinimumPay { get; set; }
        public int MaximumPay { get; set; }
        public string CvHandle { get; set; }

        public string PositionName { get; set; }
        public string JobDescription { get; set; }
        public string UsualTasks { get; set; }
        public string JobRequirements { get; set; }
        public string JobBenefits { get; set; }
    }
}
