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
        public DbSet<Document> Documents { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<TermsCondition> TermsConditions { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientContactDetail> ClientContactDetails { get; set; }
        public DbSet<ClientRelation> ClientRelations { get; set; }
    }
}