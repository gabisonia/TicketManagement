using TicketManagement.Shared;

namespace TicketManagement.Domain.Event.Events
{
    public class EventCreated : DomainEvent
    {
        public EventCreated(Event @event)
        {
            Event = @event;
        }

        public Event Event { get; }
    }
}
