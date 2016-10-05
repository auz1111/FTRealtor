using FTRealtor.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FTRealtor.DAL
{
    public class AgencyContext : DbContext
    {

        public AgencyContext() : base("AgencyContext")
        {
            Database.SetInitializer<AgencyContext>(new CreateDatabaseIfNotExists<AgencyContext>());
        }

        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}