using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class SupplementConfiguration : IEntityTypeConfiguration<Domain.supplement.Supplement>
{
    public void Configure(EntityTypeBuilder<Domain.supplement.Supplement> entity)
    {

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .HasMaxLength(200); // یا هر طول دلخواه

        entity.Property(e => e.EnglishTitle)
              .HasMaxLength(200);

        entity.Property(e => e.Description)
              .HasMaxLength(2000); // فرض بر توضیح طولانی‌تر

        entity.Property(e => e.HowToUse)
              .HasMaxLength(2000);

        // رابطه Supplement → SupplementGroup (Many-to-One)
        entity.Property(e => e.SupplementGroupId)
              .IsRequired();

        entity.HasOne(e => e.SupplementGroup)
              .WithMany(g => g.Supplement) // فرض بر اینکه SupplementGroup.Supplements وجود دارد
              .HasForeignKey(e => e.SupplementGroupId)
              .OnDelete(DeleteBehavior.Restrict);

        // رابطه Supplement → SupplementDisease_WhiteList (One-to-Many)
        entity.HasMany(e => e.SupplementDisease_WhiteList)
              .WithOne(w => w.Supplement)
              .HasForeignKey(w => w.SupplementId)
              .OnDelete(DeleteBehavior.Cascade);


        // رابطه Supplement → SupplementDurationAge (One-to-Many)
        entity.HasMany(e => e.SupplementDurationAge)
              .WithOne(w => w.Supplement)
              .HasForeignKey(w => w.SupplementId)
              .OnDelete(DeleteBehavior.Cascade);

        // رابطه Supplement → SupplementLifeCourse (One-to-Many)
        entity.HasMany(e => e.SupplementLifeCourse)
              .WithOne(w => w.Supplement)
              .HasForeignKey(w => w.SupplementId)
              .OnDelete(DeleteBehavior.Cascade);

        // رابطه Supplement → Case (Many-to-Many)
        entity.HasMany(e => e.CaseSupplement)
              .WithOne(c => c.Supplement) // فرض بر اینکه Case.Supplements در مدل Case تعریف شده
              .HasForeignKey(w => w.SupplementId)
              .OnDelete(DeleteBehavior.Cascade);
    }

}

