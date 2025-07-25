﻿using Diet.Domain.Recommendation.Entities;
using Diet.Domain.supplement.Entities;
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


