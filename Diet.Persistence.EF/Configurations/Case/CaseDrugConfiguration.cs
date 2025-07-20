using Diet.Domain.Case;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class CaseDrugConfiguration : IEntityTypeConfiguration<CaseDrug>
{
    public void Configure(EntityTypeBuilder<CaseDrug> builder)
    {


        builder.HasKey(x => x.Id);
    }

}
