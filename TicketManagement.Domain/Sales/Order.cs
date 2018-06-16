using System;
using TicketManagement.Domain.Sales.Events;
using TicketManagement.Shared;

namespace TicketManagement.Domain.Sales
{
    public class Order : AggregateRoot
    {
        public Order() { }

        public Order(string email, int ticketCount, int eventId, string eventName)
        {
            Email = email;
            TicketCount = ticketCount;
            OrderNumber = Guid.NewGuid();
            Status = OrderStatus.Active;
            CreateDate = DateTime.Now;
            Event = new Event(eventId, eventName);
            this.Raise(new OrderPlaced(eventName, eventId, ticketCount));
        }

        public string Email { get; private set; }
        public int TicketCount { get; private set; }
        public Guid OrderNumber { get; private set; }
        public float Price { get; private set; }
        public OrderStatus Status { get; private set; }
        public Event Event { get; private set; }
        public DateTime CreateDate { get; private set; }

        public void Cancel() => Status = OrderStatus.Canceled;
    }
}
