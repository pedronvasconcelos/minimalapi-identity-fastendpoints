using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Auth.Identity.Database.Mapping;

public class UserLoginMapping : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        builder.ToTable("UserLogins");
        builder.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
        builder.Property(ul => ul.UserId).HasColumnName("UserId");
    }
}
 