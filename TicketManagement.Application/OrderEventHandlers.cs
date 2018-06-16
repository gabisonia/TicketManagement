using System;
using TicketManagement.Domain.Sales.Events;
using TicketManagement.Domain.Sales.ReadModel;
using TicketManagement.Infrastructure.Db;
using TicketManagement.Infrastructure.EventDispatching;

namespace TicketManagement.Application
{
    public class OrderEventHandlers : IHandleEvent<OrderPlaced>
    {
        public void Handle(OrderPlaced @event, TicketManagementDbContext db)
        {
            var orderReadModel = new OrderReadModel()
            {
                EventName = @event.Order.Event.Name,
                OrderId = @event.Order.Id,
                TicketCount = @event.Order.TicketCount
            };
            db.Set<OrderReadModel>().Add(orderReadModel);
        }
    }
}
