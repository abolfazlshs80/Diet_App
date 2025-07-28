using Diet.Domain.recommendationDurationAge;

using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class RecommendationDurationAgeConfiguration : IEntityTypeConfiguration<RecommendationDurationAge>
{
    public void Configure(EntityTypeBuilder<RecommendationDurationAge> builder)
    {

        builder.HasKey(x => x.Id);
    }

}


