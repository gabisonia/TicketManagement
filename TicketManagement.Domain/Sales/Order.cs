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
            Status = OrderStatus.Active;
            CreateDate = DateTime.Now;
            Event = new Event(eventId, eventName);
            this.Raise(new OrderPlaced(eventName, eventId, ticketCount));
        }

        public string Email { get; }
        public int TicketCount { get; private set; }
        public float Price { get; private set; }
        public OrderStatus Status { get; private set; }
        public Event Event { get; private set; }
        public DateTime CreateDate { get; }

        public void Cancel() => Status = OrderStatus.Canceled;
    }
}
