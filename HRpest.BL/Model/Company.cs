using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HRpest.BL.Enum;

namespace HRpest.BL.Model
{
    public class Company
    {
        public int Id { get; set; }
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Edited On")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        public DateTime EditedOn { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(150, MinimumLength = 2)]
        public string Location { get; set; }
        [StringLength(1000, MinimumLength = 100)]
        public string Description { get; set; }
        [Display(Name = "Number of Employees")]
        public int NumberOfEmployees { get; set; }
        [Display(Name = "Established in")]
        [Range(1600, 2021)]
        public int YearOfEstablishment { get; set; }

        [Display(Name = "Default number of hours weekly")]
        [Range(0, 80)]
        public int DefaultNumberOfHoursWeekly {get; set; }

        [Range(0, 80)]
        [Display(Name = "Default number of remote hours weekly")]
        public int DefaultNumberOfRemoteHoursWeekly { get; set; }

        [Display(Name = "Default employment type")]
        public EmploymentType DefaultEmploymentType { get; set; }
    }
}
