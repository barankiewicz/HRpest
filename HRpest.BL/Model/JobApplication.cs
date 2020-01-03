using HRpest.BL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRpest.BL.Model
{
    public class JobApplication
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        [Display(Name = "Created on:")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [Display(Name = "Edited on:")]
        public DateTime? EditedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [Display(Name = "Deleted on:")]
        public DateTime? DeletedOn { get; set; }

        
        public User Applicant { get; set; }

        public JobOffer JobOffer { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }

        [Display(Name = "Application status:")]
        public string ApplicationStatusText { get; set; }

        [Display(Name = "CV File:")]
        public string CvHandle { get; set; }

        [Display(Name = "Additional information")]
        public string AdditionalInformation { get; set; }
    }
}
