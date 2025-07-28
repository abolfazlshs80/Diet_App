using Diet.Domain.supplementDurationAge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class SupplementDurationAgeConfiguration : IEntityTypeConfiguration<SupplementDurationAge>
{
    public void Configure(EntityTypeBuilder<SupplementDurationAge> builder)
    {
        builder.HasKey(a => a.Id);

    }

}


