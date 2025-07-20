using Diet.Domain.supplement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.Supplement;

public class SupplementGroupConfiguration : IEntityTypeConfiguration<SupplementGroup>
{
    public void Configure(EntityTypeBuilder<SupplementGroup> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Title).IsRequired();

    }

}


