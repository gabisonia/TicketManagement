using System;
using TicketManagement.Domain.Event;
using TicketManagement.Domain.Sales;

namespace TicketManagement.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {           
            var @event = new Domain.Event.Event("Snoop Dog", DateTime.Now, new Venue(new Address(1, 1), "Dinamo Arena"), 20);

            var order = new Order("irakli.gabisonia94@gmail.com", 3, @event.Id, @event.Name);
        }
    }
}
