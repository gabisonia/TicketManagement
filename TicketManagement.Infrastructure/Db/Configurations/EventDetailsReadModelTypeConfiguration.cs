using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManagement.Domain.Event.ReadModel;

namespace TicketManagement.Infrastructure.Db.Configurations
{
    public class EventDetailsReadModelTypeConfiguration : IEntityTypeConfiguration<EventDetailsReadModel>
    {
        public void Configure(EntityTypeBuilder<EventDetailsReadModel> builder)
        {
            builder.ToTable("EventsDetails", schema: "ReadModel");
        }
    }
}
