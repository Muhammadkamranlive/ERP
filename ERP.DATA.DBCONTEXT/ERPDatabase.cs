using ERP.Authentication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ERP.DATA.DBCONTEXT
{
    public class ERPDatabase : IdentityDbContext<ApplicationUser>
    {

        public ERPDatabase(DbContextOptions<ERPDatabase> dbContextOptions): base(dbContextOptions)
        {
         
        }
        public virtual DbSet<PasswordResetDomain> PasswordResetDomains { get; set; }
        
    }
}
