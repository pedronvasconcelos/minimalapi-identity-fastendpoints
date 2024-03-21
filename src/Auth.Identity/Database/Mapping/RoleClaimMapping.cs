using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Auth.Identity.Database.Mapping;

public class RoleClaimMapping : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        builder.ToTable("RoleClaims");
        builder.HasKey(rc => rc.Id);
        builder.Property(rc => rc.Id).HasColumnName("RoleClaimId");
        builder.Property(rc => rc.RoleId).HasColumnName("RoleId");
    }
}
 