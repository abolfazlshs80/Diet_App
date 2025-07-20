using Diet.Domain.supplement.Entities;
using Diet.Domain.user;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(200);

        entity.Property(e => e.Description)
              .HasMaxLength(1000);

        // رابطه Many-to-Many: Drug <-> Case
        entity.HasMany(e => e.CaseDrug)
              .WithOne(c => c.Drug) // ← باید در Case تعریف شده باشه
              .HasForeignKey(fdi => fdi.DrugId)
              .OnDelete(DeleteBehavior.Cascade);

        // رابطه One-to-Many: Drug → Food_Drug_Intraction
        entity.HasMany(e => e.Food_Drug_Intraction)
              .WithOne(fdi => fdi.Drug)
              .HasForeignKey(fdi => fdi.DrugId)
              .OnDelete(DeleteBehavior.Cascade);

    }

}


