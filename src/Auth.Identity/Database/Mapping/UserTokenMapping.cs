using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Auth.Identity.Database.Mapping;

public class UserTokenMapping : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
        builder.ToTable("UserTokens");
        builder.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
        builder.Property(ut => ut.UserId).HasColumnName("UserId");
    }
}
 