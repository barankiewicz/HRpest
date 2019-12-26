using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HRpest.BL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HRpest.DAL.Class
{
    public class HrPestContext : DbContext
    {
        public HrPestContext(DbContextOptions<HrPestContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HrPestContext>
    {
        public HrPestContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../HRPest.APP/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<HrPestContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new HrPestContext(builder.Options);
        }
    }
}
