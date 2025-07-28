using Diet.Domain.recommendation;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
{
    public void Configure(EntityTypeBuilder<Recommendation> entity)
    {

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .HasMaxLength(200);

        entity.Property(e => e.EnglishTitle)
              .HasMaxLength(200);

        entity.Property(e => e.Description)
              .HasMaxLength(2000);

        entity.Property(e => e.HowToUse)
              .HasMaxLength(2000);

        // رابطه یک‌به‌چند: Recommendation → RecommendationDisease_WhiteList
        entity.HasMany(e => e.RecommendationDisease_WhiteList)
              .WithOne(rw => rw.Recommendation) // فرض بر اینکه این Navigation Property در RecommendationDisease_WhiteList هست
              .HasForeignKey(rw => rw.RecommendationId)
              .OnDelete(DeleteBehavior.Cascade);


        // رابطه یک‌به‌چند: Recommendation → RecommendationDisease_WhiteList
        entity.HasMany(e => e.RecommendationDurationAge)
              .WithOne(rw => rw.Recommendation) // فرض بر اینکه این Navigation Property در RecommendationDisease_WhiteList هست
              .HasForeignKey(rw => rw.RecommendationId)
              .OnDelete(DeleteBehavior.Cascade);

        // رابطه یک‌به‌چند: Recommendation → RecommendationDisease_WhiteList
        entity.HasMany(e => e.RecommendationLifeCourse)
              .WithOne(rw => rw.Recommendation) // فرض بر اینکه این Navigation Property در RecommendationDisease_WhiteList هست
              .HasForeignKey(rw => rw.RecommendationId)
              .OnDelete(DeleteBehavior.Cascade);
    }

}


