using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManagement.Domain.Event.ReadModel;

namespace TicketManagement.Infrastructure.Db.Configurations
{
    public class EventsListReadModelTypeConfiguration : IEntityTypeConfiguration<EventsListReadModel>
    {
        public void Configure(EntityTypeBuilder<EventsListReadModel> builder)
        {
            builder.ToTable("EventsList", schema: "ReadModel");
        }
    }
}
