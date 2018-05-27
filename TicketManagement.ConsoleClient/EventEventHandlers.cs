using System;
using TicketManagement.Domain.Event.Events;
using TicketManagement.Infrastructure.Db;
using TicketManagement.Infrastructure.EventDispatching;

namespace TicketManagement.ConsoleClient
{
    public class EventEventHandlers : IHandleEvent<EventCreated>
    {
        public void Handle(EventCreated @event, TicketManagementDbContext db)
        {
            Console.WriteLine("Event Created");
        }
    }
}
