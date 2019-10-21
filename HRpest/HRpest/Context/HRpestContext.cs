using HRpest.Models;
using Microsoft.EntityFrameworkCore;



namespace HRpest.Context
{
    public class HRpestContext : DbContext
    {
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
