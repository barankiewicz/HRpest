using HRpest.BL.Enum;
using System;
using System.ComponentModel.DataAnnotations;


namespace HRpest.BL.Model
{
    public class JobOffer
    {
        public int Id { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [Display(Name = "Active Until")]
        public DateTime? ActiveUntil { get; set; }
        [Display(Name = "Created By")]
        public User? CreatedBy { get; set; }

        [Display(Name = "Employment Type")]
        [Required]
        public EmploymentType EmploymentType { get; set; }
        [Display(Name = "Seniority Level")]
        [Required]
        public PositionLevel PositionLevel { get; set; }
        [Display(Name = "Hours per week")]
        [Required]
        public int HoursWeekly { get; set; }
        [Display(Name = "Remote hours per week")]
        public int? RemoteHoursWeekly { get; set; }
        [Display(Name = "Minimum Pay")]
        [Required]
        public int MinimumPay { get; set; }
        [Display(Name = "Maximum Pay")]
        public int? MaximumPay { get; set; }

        [Display(Name = "Job Title")]
        [Required]
        public string PositionName { get; set; }
        [Display(Name = "Job Description")]
        [Required]
        public string JobDescription { get; set; }
        [Display(Name = "Usual Tasks")]
        public string UsualTasks { get; set; }
        [Display(Name = "Job Requirements")]
        public string JobRequirements { get; set; }
        [Display(Name = "Job Benefits")]
        public string JobBenefits { get; set; }
    }
}
