using System;
using TicketManagement.Shared;

namespace TicketManagement.Domain.Event.Events
{
    public class EventCreated : DomainEvent
    {
        public EventCreated(string eventName, string venueName, DateTime eventDate, int eventId)
        {
            AggregateRootId = eventId;
            EventName = EventName;
            VenueName = venueName;
        }

        public string EventName { get; }
        public string VenueName { get; }
        public DateTime EventDate { get; }
    }
}
