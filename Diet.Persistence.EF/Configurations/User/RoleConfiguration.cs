using Diet.Domain.role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(100);

        entity.HasMany(a => a.UserRoles)
  .WithOne(a => a.Role)
  .HasForeignKey(a => a.RoleId)
  .OnDelete(DeleteBehavior.Cascade);
    }

}

