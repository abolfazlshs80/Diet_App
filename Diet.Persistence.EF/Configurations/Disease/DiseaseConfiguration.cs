using Diet.Domain.disease;
using Diet.Domain.supplement.Entities;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class DiseaseConfiguration : IEntityTypeConfiguration<Domain.disease.Disease>
{
    public void Configure(EntityTypeBuilder<Domain.disease.Disease> entity)
    {

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(200);

        entity.Property(e => e.ParentId)
              .IsRequired(false); // اگر بعضی بیماری‌ها والد ندارند

        // Self-referencing relation: Parent <-> Children
        //entity.HasOne(e => e.Parent)
        //      .WithMany(e => e.Childeren)
        //      .HasForeignKey(e => e.ParentId)
        //      .OnDelete(DeleteBehavior.Restrict); // جلوگیری از حذف والد اگر فرزند دارد

        // One-to-Many: Disease → SupplementDisease_WhiteList
        entity.HasMany(e => e.SupplementDisease_WhiteList)
              .WithOne(w => w.Disease)
              .HasForeignKey(w => w.DiseaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Disease → RecommendationDisease_WhiteList
        entity.HasMany(e => e.RecommendationDisease_WhiteList)
              .WithOne(w => w.Disease)
              .HasForeignKey(w => w.DiseaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many (Many-to-Many via join): Disease → CaseDisease
        entity.HasMany(e => e.CaseDisease)
              .WithOne(cd => cd.Disease)
              .HasForeignKey(cd => cd.DiseaseId)
              .OnDelete(DeleteBehavior.Cascade);
    }

}


