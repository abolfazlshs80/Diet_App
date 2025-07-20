using Diet.Domain.supplement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class SupplementLifeCourseConfiguration : IEntityTypeConfiguration<SupplementLifeCourse>
{
    public void Configure(EntityTypeBuilder<SupplementLifeCourse> builder)
    {
        builder.HasKey(a => a.Id);


    }

}


