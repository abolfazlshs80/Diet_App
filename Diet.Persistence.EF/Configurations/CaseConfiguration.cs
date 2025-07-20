


using Diet.Domain.Case;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.EF.Configurations;

public class CaseConfiguration : IEntityTypeConfiguration<Case>
{
    public void Configure(EntityTypeBuilder<Case> builder)
    {
        builder.
            HasOne(a => a.Transactions).
            WithMany(a => a.Case)
            .HasForeignKey(a => a.TransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.
     HasOne(a => a.Sport).
     WithMany(a => a.Case)
     .HasForeignKey(a => a.SportId)
     .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.LifeCourse)
.WithMany(a => a.Case)
.HasForeignKey(a => a.LifeCourseId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Drug)
            .WithMany(a => a.Case);

        //builder.HasMany(a => a.UnPleasantFood)
        //  .WithMany(a => a.Case);

        //builder.HasMany(a => a.PleasantFood)
        //  .WithMany(a => a.Case);

        builder.HasMany(a => a.FoodStuffAllergy)
          .WithMany(a => a.Case);

        builder.HasMany(a => a.Supplement)
    .WithMany(a => a.Case);
    }

}
