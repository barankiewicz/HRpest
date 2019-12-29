using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }
        [Display(Name = "Number of Employees")]
        public int NumberOfEmployees { get; set; }
        [Display(Name = "Established in")]
        public int YearOfEstablishment { get; set; }
    }
}
