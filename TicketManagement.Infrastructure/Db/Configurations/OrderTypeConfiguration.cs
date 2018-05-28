using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManagement.Domain.Sales;

namespace TicketManagement.Infrastructure.Db.Configurations
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", schema: "WriteModel");
            builder.OwnsOne(x => x.Event).Property(v => v.Name).HasColumnName("EventName");
            builder.OwnsOne(x => x.Event).Property(v => v.Id).HasColumnName("EventId");
        }
    }
}
