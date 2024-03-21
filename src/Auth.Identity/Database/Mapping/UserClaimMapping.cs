using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Auth.Identity.Database.Mapping;

public class UserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
        builder.ToTable("UserClaims");
        builder.HasKey(uc => uc.Id);
        builder.Property(uc => uc.Id).HasColumnName("UserClaimId");
        builder.Property(uc => uc.UserId).HasColumnName("UserId");
    }
}
 