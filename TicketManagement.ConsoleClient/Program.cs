using System;
using TicketManagement.Application.Commands;
using TicketManagement.Domain.Event;
using TicketManagement.Domain.Sales;

namespace TicketManagement.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventCreateCommand = new CreateEventCommand()
            {
                EventDate = DateTime.Now,
                EventName = "test",
                Latitude = 1,
                Longitude = 2,
                SeatCount = 23,
                VenueName = "t"
            }.Execute();
        }
    }
}
