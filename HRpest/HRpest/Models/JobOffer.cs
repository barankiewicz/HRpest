using HRpest.Enums;
using System;

namespace HRpest.Models
{
	public class JobOffer
    {
		public int Id { get; set; }
		public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public decimal Salary { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
