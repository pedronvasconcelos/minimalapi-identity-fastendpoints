using Auth.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Database;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, 
    ApplicationRole,
    Guid, 
    ApplicationUserClaim, 
    ApplicationUserRole, 
    ApplicationUserLogin, 
    ApplicationRoleClaim, 
    ApplicationUserToken>
{

    
   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var relationship in builder.Model.GetEntityTypes()
                 .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }

        _ = builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }
}
