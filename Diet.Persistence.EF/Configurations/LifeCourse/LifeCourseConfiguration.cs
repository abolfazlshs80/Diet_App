using Diet.Domain.lifeCourse;
using Diet.Domain.supplement.Entities;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class LifeCourseConfiguration : IEntityTypeConfiguration<LifeCourse>
{
    public void Configure(EntityTypeBuilder<LifeCourse> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(200);

        entity.Property(e => e.ParentId)
              .IsRequired();

        // Self-referencing relationship
        entity.HasOne(e => e.Parent)
              .WithMany(e => e.Children)
              .HasForeignKey(e => e.ParentId)
              .OnDelete(DeleteBehavior.Restrict); // یا Cascade، بسته به نیاز

        // Many-to-Many: LifeCourse <-> Case (فرض بر اینکه Case.LifeCourses تعریف شده)
        entity.HasMany(e => e.Case)
              .WithOne(c => c.LifeCourse) // باید در Case تعریف شود
                  .HasForeignKey(sl => sl.LifeCourseId)
              .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: LifeCourse -> SupplementLifeCourse
        entity.HasMany(e => e.SupplementLifeCourse)
              .WithOne(sl => sl.LifeCourse)
              .HasForeignKey(sl => sl.LifeCourseId)
              .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: LifeCourse -> RecommendationLifeCourse
        entity.HasMany(e => e.RecommendationLifeCourse)
              .WithOne(rl => rl.LifeCourse)
              .HasForeignKey(rl => rl.LifeCourseId)
              .OnDelete(DeleteBehavior.Cascade);

    }

}


