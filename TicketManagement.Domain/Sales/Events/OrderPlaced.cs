using TicketManagement.Shared;

namespace TicketManagement.Domain.Sales.Events
{
    public class OrderPlaced : DomainEvent
    {
        public OrderPlaced(string eventName, int eventId, int ticketCount)
        {
            AggregateRootId = eventId;
            EventName = EventName;
            TicketCount = ticketCount;
        }

        public string EventName { get; }
        public int TicketCount { get; }
    }
}
