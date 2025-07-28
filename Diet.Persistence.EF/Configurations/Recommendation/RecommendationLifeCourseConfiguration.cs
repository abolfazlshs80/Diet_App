using Diet.Domain.recommendationLifeCourse;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class RecommendationLifeCourseConfiguration : IEntityTypeConfiguration<RecommendationLifeCourse>
{
    public void Configure(EntityTypeBuilder<RecommendationLifeCourse> builder)
    {

        builder.HasKey(x => x.Id);
    }

}


