using Diet.Domain.Case;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class CaseDiseaseConfiguration : IEntityTypeConfiguration<CaseDisease>
{
    public void Configure(EntityTypeBuilder<CaseDisease> builder)
    {


        builder.HasKey(x => x.Id);
    }

}


