using HRpest.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRpest.DAL.Class
{
    static public class DataSeeder
    {
        public static void AddJobOffers(HrPestContext context)
        {

            if(context.JobOffers.Count() <= 1)
            {
                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.First((User u) => u.UserType == BL.Enum.UserType.HR),
                    CreatedOn = DateTime.Now,
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

        
    }
}
