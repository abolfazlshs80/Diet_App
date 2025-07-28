using Diet.Domain.durationAge.Entities;

using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class DurationAgeConfiguration : IEntityTypeConfiguration<DurationAge>
{
    public void Configure(EntityTypeBuilder<DurationAge> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(200);

        // رابطه One-to-Many با SupplementDurationAge
        entity.HasMany(e => e.SupplementDurationAge)
              .WithOne(sda => sda.DurationAge)
              .HasForeignKey(sda => sda.DurationAgeId)
              .OnDelete(DeleteBehavior.Cascade);

        // رابطه One-to-Many با RecommendationDurationAge
        entity.HasMany(e => e.RecommendationDurationAge)
              .WithOne(rda => rda.DurationAge)
              .HasForeignKey(rda => rda.DurationAgeId)
              .OnDelete(DeleteBehavior.Cascade);

    }

}


