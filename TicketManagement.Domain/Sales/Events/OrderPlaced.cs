using TicketManagement.Shared;

namespace TicketManagement.Domain.Sales.Events
{
    public class OrderPlaced : DomainEvent
    {
        public OrderPlaced(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
