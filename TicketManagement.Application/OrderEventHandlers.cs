using System;
using TicketManagement.Domain.Sales.Events;
using TicketManagement.Infrastructure.Db;
using TicketManagement.Infrastructure.EventDispatching;

namespace TicketManagement.Application
{
    public class OrderEventHandlers : IHandleEvent<OrderPlaced>
    {
        public void Handle(OrderPlaced @event, TicketManagementDbContext db)
        {
            Console.WriteLine("Order Placed");
        }
    }
}
