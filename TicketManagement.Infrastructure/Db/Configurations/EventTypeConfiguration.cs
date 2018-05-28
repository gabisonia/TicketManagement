using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManagement.Domain.Event;

namespace TicketManagement.Infrastructure.Db.Configurations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Venue).Property(v => v.Name).HasColumnName("VenueName");
            builder.OwnsOne(x => x.Venue).Property(l => l.Latitude).HasColumnName("Latitude");
            builder.OwnsOne(x => x.Venue).Property(l => l.Longitude).HasColumnName("Longitude");
            builder.ToTable("Events", schema: "WriteModel");
        }
    }
}
