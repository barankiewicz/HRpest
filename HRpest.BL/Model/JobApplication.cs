using HRpest.BL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRpest.BL.Model
{
    public class JobApplication
    {
        public int Id{ get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public User Applicant { get; set; }
        public JobOffer JobOffer { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string CvHandle { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
