using ContactManagement;
using ERP.HRAdminStaff.Domain;
using ERP.Notifications.Domain;
using ERP.Authentication.Domain;
using ERP.CaseManagement.Domain;
using ERP.TaskManagement.Domain;
using ERP.ProfileManagement.Domain;
using Microsoft.EntityFrameworkCore;
using ERP.DocumentManagement.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.DataBase
{
    public class ERPDb : IdentityDbContext<ApplicationUser>
    {
        public ERPDb(DbContextOptions<ERPDb> dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<PasswordResetDomain> PasswordResetDomains { get; set; }
        public virtual DbSet<CONTACTDETAILS> CONTACTDETAILs { get; set; }
        public virtual DbSet<EmergencyContacts> EmergencyContacts { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseComment> CaseComments { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<HRNotes> HRNotes { get; set; }
        public virtual DbSet<NOTIFICATIONS> NOTIFICATIONs { get; set; }
        public virtual DbSet<CandidateInfo> CandidateInfos { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<JobExperience> JobExperiences { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<ProfessionalLicense> ProfessionalLicenses { get; set; }
        public virtual DbSet<GENERALTASK> GENERALTASKs { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure all entities with Id of type Guid
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check if the entity has an Id property
                var idProperty  = entityType.FindProperty("Id");
                if (idProperty != null && idProperty.ClrType == typeof(Guid))
                {
                    // Configure Id as primary key
                    modelBuilder.Entity(entityType.Name)
                        .HasKey("Id")
                        .HasName($"PK_{entityType.Name}_Id");

                    // Configure Id to be generated on add
                    modelBuilder.Entity(entityType.Name)
                        .Property<Guid>("Id")
                        .ValueGeneratedOnAdd();
                    modelBuilder.Entity<Asset>()
                   .Property(a => a.Price)
                   .HasPrecision(18, 2); // Adjust precision and scale as needed
                }
            }
        }

    }
}