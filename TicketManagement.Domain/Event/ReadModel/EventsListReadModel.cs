using System;

namespace TicketManagement.Domain.Event.ReadModel
{
    public class EventsListReadModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string VenueName { get; set; }
        public bool IsSoldOut { get; set; }
    }
}
