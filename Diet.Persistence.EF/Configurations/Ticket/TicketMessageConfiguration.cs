using Diet.Domain.ticket.Entities;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class TicketMessageConfiguration : IEntityTypeConfiguration<TicketMessage>
{
    public void Configure(EntityTypeBuilder<TicketMessage> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.TextMessage)
              .IsRequired()
              .HasMaxLength(1000); // یا هر محدودیتی که نیاز داری

        entity.Property(e => e.FileName)
              .HasMaxLength(255); // قابل null بودن یا نبودن بستگی به طراحی شما داره

        entity.Property(e => e.TicketId)
              .IsRequired();

        entity.HasOne(e => e.Ticket)
              .WithMany(t => t.Messages)
              .HasForeignKey(e => e.TicketId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.Property(e => e.FromId)
              .IsRequired();

        entity.HasOne(e => e.FromUser)
              .WithMany(_=>_.FormTicketMessage) // اگه کاربر پیام‌های زیادی داشته باشه می‌تونی WithMany(u => u.TicketMessages) بنویسی
              .HasForeignKey(e => e.FromId)
              .OnDelete(DeleteBehavior.Restrict);

    }

}

