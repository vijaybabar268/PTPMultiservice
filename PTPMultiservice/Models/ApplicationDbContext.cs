using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System.Data.Entity;

namespace PTPMultiservice.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MySql_CS", throwIfV1Schema: false)
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            return new ApplicationDbContext();
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Partner> Partners { get; set; }    
    }
}