using HRpest.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRpest.DAL.Class
{
    static public class DataSeeder
    {
        public static void DeleteJobOffers(HrPestContext context)
        {
            context.JobApplications.RemoveRange(context.JobApplications.Where(x => x.JobOffer != null));
            context.JobOffers.RemoveRange(context.JobOffers.Where(x=> x.Id != null));
            context.SaveChanges();
        }

        public static void DeleteCompanies (HrPestContext context)
        {
            
            context.Companies.RemoveRange(context.Companies.Where(x => x.CreatedOn != null));
            context.SaveChanges();
        }
        public static void AddJobOffers(HrPestContext context)
        {
            if(context.JobOffers.Count() <= 1)
            {
                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.First((User u) => u.UserType == BL.Enum.UserType.HR),
                    CreatedOn = DateTime.Now,
                    CreatedFor = context.Companies.Where(x=> x.Name == "Google").FirstOrDefault(),
                    Location = "Warsaw",
                    EmploymentType = BL.Enum.EmploymentType.B2B,
                    ActiveUntil = DateTime.Now.AddDays(120),
                    HoursWeekly = 40,
                    JobBenefits = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    JobDescription = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    JobRequirements = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    MaximumPay = 10000,
                    MinimumPay = 5000,
                    PositionLevel = BL.Enum.PositionLevel.ENTRY_LEVEL,
                    PositionName = "Mistrz swiata",
                    RemoteHoursWeekly = 8,
                    UsualTasks = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam"
                });

                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.First((User u) => u.UserType == BL.Enum.UserType.HR),
                    CreatedOn = DateTime.Now.AddDays(-3),
                    EmploymentType = BL.Enum.EmploymentType.B2B,
                    ActiveUntil = DateTime.Now.AddDays(-1),
                    HoursWeekly = 40,
                    CreatedFor = context.Companies.Where(x => x.Name == "Google").FirstOrDefault(),
                    Location = "Warsaw",
                    JobBenefits = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    JobDescription = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    JobRequirements = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    MaximumPay = 3000,
                    MinimumPay = 1000,
                    PositionLevel = BL.Enum.PositionLevel.JUNIOR,
                    PositionName = "Mistrz swiata",
                    RemoteHoursWeekly = 8,
                    UsualTasks = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam"
                });

                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.First((User u) => u.UserType == BL.Enum.UserType.HR),
                    CreatedOn = DateTime.Now,
                    EmploymentType = BL.Enum.EmploymentType.B2B,
                    ActiveUntil = DateTime.Now.AddDays(120),
                    HoursWeekly = 120,
                    CreatedFor = context.Companies.Where(x => x.Name == "Google").FirstOrDefault(),
                    Location = "Warsaw",
                    JobBenefits = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    JobDescription = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    JobRequirements = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam",
                    MaximumPay = 10000,
                    MinimumPay = 5000,
                    PositionLevel = BL.Enum.PositionLevel.ENTRY_LEVEL,
                    PositionName = "Mistrz swiata",
                    RemoteHoursWeekly = 8,
                    UsualTasks = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam"
                });

                context.SaveChanges();
            }
        }

        public static void AddCompanies(HrPestContext context)
        {
            if (context.Companies.Count() <= 1)
            {
                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    Name = "Google"
                });

                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    Name = "Microsoft"
                });

                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    Name = "Intel"
                });

                context.SaveChanges();
            }
        }
    }
}
