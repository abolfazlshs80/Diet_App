using Diet.Domain.sport;
using Diet.Domain.supplement.Entities;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> entity)
    {

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(100); // تنظیم دلخواه برای طول نام ورزش

        entity.Property(e => e.Low)
              .IsRequired();

        entity.Property(e => e.Medium)
              .IsRequired();

        entity.Property(e => e.High)
              .IsRequired();

        // Many-to-Many relation: Sport <-> Case
        entity.HasMany(e => e.Case)
              .WithOne(c => c.Sport) // فرض بر اینکه Case.Sports در کلاس Case تعریف شده
              .HasForeignKey(_ => _.SportId)
              .OnDelete(DeleteBehavior.Restrict);
    }

}


