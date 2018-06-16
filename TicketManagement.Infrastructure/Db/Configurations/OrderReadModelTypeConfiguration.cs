using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManagement.Domain.Sales.ReadModel;

namespace TicketManagement.Infrastructure.Db.Configurations
{
    public class OrderReadModelTypeConfiguration : IEntityTypeConfiguration<OrderReadModel>
    {
        public void Configure(EntityTypeBuilder<OrderReadModel> builder)
        {
            builder.ToTable("OrderReadModel", schema: "ReadModel");
        }
    }
}
