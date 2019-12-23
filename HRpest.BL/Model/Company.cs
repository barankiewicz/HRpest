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

        [Required]
        public string Name { get; set; }
    }
}
