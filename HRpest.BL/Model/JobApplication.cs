using HRpest.BL.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRpest.BL.Model
{
    public class JobApplication
    {
        public int Id{ get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [Display(Name = "Edited on:")]
        public DateTime? EditedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [Display(Name = "Deleted on:")]
        public DateTime? DeletedOn { get; set; }

        [Required]
        public User Applicant { get; set; }
        [Required]
        public JobOffer JobOffer { get; set; }
        [Required]
        public ApplicationStatus ApplicationStatus { get; set; }

        public string CvHandle { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
