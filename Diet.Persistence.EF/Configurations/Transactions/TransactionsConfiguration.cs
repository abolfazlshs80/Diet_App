using Diet.Domain.transactions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class TransactionsConfiguration : IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.TotalPrice)
            .IsRequired();

        builder.Property(p => p.ZarinPalAuthority)
            .HasMaxLength(100); 

        builder.Property(p => p.ZarinPalRefNum)
            .HasMaxLength(100);

        builder.Property(p => p.TransactionType)
            .HasConversion<int>() // ذخیره‌سازی enum به صورت int
            .IsRequired();

        builder.HasMany(a => a.Case)
            .WithOne(a => a.Transactions)
            .HasForeignKey(a => a.TransactionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}

