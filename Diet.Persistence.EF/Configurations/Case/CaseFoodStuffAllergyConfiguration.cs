using Diet.Domain.caseFoodStuffAllergy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class CaseFoodStuffAllergyConfiguration : IEntityTypeConfiguration<CaseFoodStuffAllergy>
{
    public void Configure(EntityTypeBuilder<CaseFoodStuffAllergy> builder)
    {


        builder.HasKey(x => x.Id);
    }

}
