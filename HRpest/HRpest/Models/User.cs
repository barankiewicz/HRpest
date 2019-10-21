using HRpest.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRpest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
