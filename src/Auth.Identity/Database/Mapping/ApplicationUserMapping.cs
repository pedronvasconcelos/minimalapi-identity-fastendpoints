using Auth.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Auth.Identity.Database.Mapping;

public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("UserId");
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(256);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(256);
        builder.Property(u => u.EmailConfirmed);
        builder.Property(u => u.PasswordHash);
        builder.Property(u => u.SecurityStamp);
        builder.Property(u => u.ConcurrencyStamp);
        builder.Property(u => u.PhoneNumber).HasMaxLength(15);
        builder.Property(u => u.PhoneNumberConfirmed);
        builder.Property(u => u.TwoFactorEnabled);
        builder.Property(u => u.LockoutEnd);
        builder.Property(u => u.LockoutEnabled);
        builder.Property(u => u.AccessFailedCount);
        builder.Property(u=>u.RefreshToken).HasMaxLength(1000); 
        builder.Property(u=>u.RefreshTokenExpiryTime);      



        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).IsUnique();
        builder.HasIndex(u => u.UserName).IsUnique();
        builder.HasIndex(u => u.NormalizedUserName).IsUnique();
        

    }
}
 