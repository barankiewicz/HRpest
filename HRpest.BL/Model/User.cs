using HRpest.BL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRpest.BL.Model
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        //public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return Name + " " + Surname; } }
        public string? PhoneNumber { get; set; }
        public string? GithubAccount { get; set; }
        public UserType UserType { get; set; }
    }
}
