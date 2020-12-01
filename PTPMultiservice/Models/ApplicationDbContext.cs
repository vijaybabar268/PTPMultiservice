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
        public DbSet<PartnerDocument> PartnerDocuments { get; set; }
        public DbSet<PartnerBankDetail> PartnerBankDetails { get; set; }
        public DbSet<PartnerTermsCondition> PartnerTermsConditions { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientContactDetail> ClientContactDetails { get; set; }
        public DbSet<ClientRelation> ClientRelations { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDocumentDetail> EmployeeDocumentDetails { get; set; }
        public DbSet<EmployeeBankDetail> EmployeeBankDetails { get; set; }
        public DbSet<EmployeePfDetail> EmployeePfDetails { get; set; }
        public DbSet<EmployeeStateInsuranceDetail> EmployeeStateInsuranceDetails { get; set; }
        public DbSet<EmployeeStateInsuranceFamilyDetail> EmployeeStateInsuranceFamilyDetails { get; set; }
        
        public DbSet<PartnerClientsMapping> PartnerClientsMapping { get; set; }


    }
}