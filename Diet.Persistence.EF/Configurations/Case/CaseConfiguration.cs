using Diet.Domain.Case;

using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;


public class CaseConfiguration : IEntityTypeConfiguration<Case>
{
    public void Configure(EntityTypeBuilder<Case> entity)
    {

        entity.HasKey(e => e.Id);

        // فیلدهای اصلی
        entity.Property(e => e.Weight).IsRequired();
        entity.Property(e => e.Height).IsRequired();

        entity.Property(e => e.BirthDate)
              .IsRequired()
              .HasMaxLength(10); // فرض بر YYYY-MM-DD

        entity.Property(e => e.Description)
              .HasMaxLength(1000);

        entity.Property(e => e.Gender)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.BodyActivity)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.IsSport)
              .IsRequired();

        entity.Property(e => e.SportActivity)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.ChangeWeightType)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.WeightChangeAmount);

        entity.Property(e => e.ExerciseTime);

        entity.Property(e => e.ExerciseDay)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.DateOfStart)
              .IsRequired();

        entity.Property(e => e.BodyForm)
              .HasConversion<int>()
              .IsRequired();

        // Sport (optional many-to-one)
        entity.HasOne(e => e.Sport)
              .WithMany(s => s.Case)
              .HasForeignKey(e => e.SportId)
              .OnDelete(DeleteBehavior.SetNull); // چون SportId nullable هست

        // LifeCourse (required many-to-one)
        entity.HasOne(e => e.LifeCourse)
              .WithMany(lc => lc.Case)
              .HasForeignKey(e => e.LifeCourseId)
              .OnDelete(DeleteBehavior.Restrict);

        // User (required many-to-one)
        entity.HasOne(e => e.User)
              .WithMany(u => u.Case)
              .HasForeignKey(e => e.UserId)
              .OnDelete(DeleteBehavior.Restrict);

        // Transactions (required one-to-one)
        entity.
          HasOne(a => a.Transactions).
          WithMany(a => a.Case)
          .HasForeignKey(a => a.TransactionId)
          .OnDelete(DeleteBehavior.Restrict);

        // CaseDrug
        entity.HasMany(e => e.CaseDrug)
              .WithOne(cd => cd.Case)
              .HasForeignKey(cd => cd.CaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // CaseDisease
        entity.HasMany(e => e.Disease)
              .WithOne(cd => cd.Case)
              .HasForeignKey(cd => cd.CaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // CaseSupplement
        entity.HasMany(e => e.CaseSupplement)
              .WithOne(cs => cs.Case)
              .HasForeignKey(cs => cs.CaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // CaseFoodStuffAllergy
        entity.HasMany(e => e.FoodStuffAllergy)
              .WithOne(ca => ca.Case)
              .HasForeignKey(ca => ca.CaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // CasePleasantFood
        entity.HasMany(e => e.PleasantFood)
              .WithOne(pf => pf.Case)
              .HasForeignKey(pf => pf.CaseId)
              .OnDelete(DeleteBehavior.Cascade);

        // CaseUnPleasantFood
        entity.HasMany(e => e.UnPleasantFood)
              .WithOne(uf => uf.Case)
              .HasForeignKey(uf => uf.CaseId)
              .OnDelete(DeleteBehavior.Cascade);
    }

}
