using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Auth.Identity.Database.Mapping;

public class RoleMapping : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("RoleId");
        builder.Property(r => r.Name).IsRequired().HasMaxLength(256);
        builder.Property(r => r.NormalizedName).HasMaxLength(256);
        builder.Property(r => r.ConcurrencyStamp);
        builder.HasIndex(r => r.Name).IsUnique();
        builder.HasIndex(r => r.NormalizedName).IsUnique();
    }
}
 