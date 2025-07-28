using Diet.Domain.recommendationLifeCourse;

using Diet.Domain.user.Entities;
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


