using HRpest.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRpest.BL.Helpers;

namespace HRpest.DAL.Class
{
    static public class DataSeeder
    {
        public static void DeleteEverything(HrPestContext context)
        {
            context.JobApplications.RemoveRange(context.JobApplications.Where(x => x.JobOffer != null));
            context.JobOffers.RemoveRange(context.JobOffers.Where(x => x.Id != null));
            context.Companies.RemoveRange(context.Companies.Where(x => x.CreatedOn != null));
            context.Users.RemoveRange(context.Users.Where(x => x.Id != null));
            context.SaveChanges();
        }

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

        public static void DeleteUsers(HrPestContext context)
        {
            context.JobApplications.RemoveRange(context.JobApplications.Where(x => x.Id != null));
            context.Users.RemoveRange(context.Users.Where(x => x.Id != null));
            context.SaveChanges();
        }

        public static void AddEverything(HrPestContext context)
        {
            AddUsers(context);
            AddCompanies(context);
            context.SaveChanges();
            AddJobOffers(context);
            context.SaveChanges();
            AddJobApplications(context);
            context.SaveChanges();
        }

        public static void AddJobOffers(HrPestContext context)
        {
            if(context.JobOffers.Count() <= 1)
            {
                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.Where(u=>u.UserType == BL.Enum.UserType.HR).FirstOrDefault(),
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
                    PositionName = "Mistrz swiata 1",
                    RemoteHoursWeekly = 8,
                    UsualTasks = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam"
                });

                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.Where(u => u.UserType == BL.Enum.UserType.HR).FirstOrDefault(),
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
                    PositionName = "Mistrz swiata 2",
                    RemoteHoursWeekly = 8,
                    UsualTasks = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam"
                });

                context.JobOffers.Add(new BL.Model.JobOffer
                {
                    CreatedBy = context.Users.Where(u => u.UserType == BL.Enum.UserType.HR).FirstOrDefault(),
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
                    PositionName = "Mistrz swiata 3",
                    RemoteHoursWeekly = 8,
                    UsualTasks = "Costam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam CostamCostam Costam"
                });
            }
        }

        public static void AddCompanies(HrPestContext context)
        {
            if (context.Companies.Count() <= 1)
            {
                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    Name = "Google",
                    Description = "DNWIJDIAWHIUDHWAIUHDIUAWHIDHUIAWYDHIUWAIUHDIUAWHDIUIWAUHDIUWAHDIUAWIHDIUHWAIHUDAW",
                    Location = "Warsaw",
                    NumberOfEmployees = 10000,
                    YearOfEstablishment = 1980
                });

                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    Name = "Microsoft",
                    Description = "DNWIJDIAWHIUDHWAIUHDIUAWHIDHUIAWYDHIUWAIUHDIUAWHDIUIWAUHDIUWAHDIUAWIHDIUHWAIHUDAW",
                    Location = "Sillicon Valley",
                    NumberOfEmployees = 40,
                    YearOfEstablishment = 1920
                });

                context.Companies.Add(new BL.Model.Company
                {
                    EditedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    Name = "Intel",
                    Description = "DNWIJDIAWHIUDHWAIUHDIUAWHIDHUIAWYDHIUWAIUHDIUAWHDIUIWAUHDIUWAHDIUAWIHDIUHWAIHUDAW",
                    Location = "Boston",
                    NumberOfEmployees = 1000,
                    YearOfEstablishment = 2010
                });

                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    Name = "Apple",
                    Description = "DNWIJDIAWHIUDHWAIUHDIUAWHIDHUIAWYDHIUWAIUHDIUAWHDIUIWAUHDIUWAHDIUAWIHDIUHWAIHUDAW",
                    Location = "Warsaw",
                    NumberOfEmployees = 10000,
                    YearOfEstablishment = 1980
                });

                context.Companies.Add(new BL.Model.Company
                {
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    Name = "HP",
                    Description = "DNWIJDIAWHIUDHWAIUHDIUAWHIDHUIAWYDHIUWAIUHDIUAWHDIUIWAUHDIUWAHDIUAWIHDIUHWAIHUDAW",
                    Location = "Sillicon Valley",
                    NumberOfEmployees = 40,
                    YearOfEstablishment = 1980
                });

                context.Companies.Add(new BL.Model.Company
                {
                    EditedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    Name = "TescikTescik",
                    Description = "DNWIJDIAWHIUDHWAIUHDIUAWHIDHUIAWYDHIUWAIUHDIUAWHDIUIWAUHDIUWAHDIUAWIHDIUHWAIHUDAW",
                    Location = "Boston",
                    NumberOfEmployees = 1000,
                    YearOfEstablishment = 1980
                });
            }
        }

        public static void AddUsers(HrPestContext context)
        {
            if (context.Users.Count() <= 1)
            {
                context.Users.Add(new BL.Model.User
                {
                    EmailAddress = "costam@costam.pl",
                    Name = "Filip",
                    Surname = "Doe",
                    UserType = BL.Enum.UserType.APPLICANT,
                    GithubAccount = "spankie1337"
                });

                context.Users.Add(new BL.Model.User
                {
                    EmailAddress = "costam@costam.pl",
                    Name = "Jane",
                    Surname = "Doe",
                    UserType = BL.Enum.UserType.HR
                });
            }
        }

        public static void AddJobApplications (HrPestContext context)
        {
            if (context.JobApplications.Count() <= 1)
            {
                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidhiawd",
                    Applicant = context.Users.FirstOrDefault(x=>x.Name == "Filip"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.NO_DECISION_MADE,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.NO_DECISION_MADE),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x=>x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidwadwadawdawddhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Jane"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdwadwadawdawdawdawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Filip"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.NO_DECISION_MADE,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.NO_DECISION_MADE),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidwadwadawdawddhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Jane"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdwadwadawdawdawdawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidwadwadawdawddhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Jane"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdwadwadawdawdawdawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidwadwadawdawddhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Jane"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdwadwadawdawdawdawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidwadwadawdawddhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Jane"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdwadwadawdawdawdawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidwadwadawdawddhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Jane"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdwadwadawdawdawdawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 1")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Filip"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.REJECTED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.REJECTED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 2")
                });

                context.JobApplications.Add(new BL.Model.JobApplication
                {
                    AdditionalInformation = "dhwudahwidhiawd",
                    Applicant = context.Users.FirstOrDefault(x => x.Name == "Filip"),
                    ApplicationStatus = BL.Enum.ApplicationStatus.APPROVED,
                    ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.APPROVED),
                    CreatedOn = DateTime.Now,
                    EditedOn = DateTime.Now,
                    CvHandle = "Djwidoawdhjoiwa",
                    JobOffer = context.JobOffers.FirstOrDefault(x => x.PositionName == "Mistrz swiata 3")
                });
            }
        }
    }
}
