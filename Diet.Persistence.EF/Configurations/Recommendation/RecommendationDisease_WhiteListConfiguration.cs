﻿using Diet.Domain.Recommendation.Entities;
using Diet.Domain.supplement.Entities;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class RecommendationDisease_WhiteListConfiguration : IEntityTypeConfiguration<RecommendationDisease_WhiteList>
{
    public void Configure(EntityTypeBuilder<RecommendationDisease_WhiteList> builder)
    {
        builder.HasKey(_ => _.Id);

    }

}


