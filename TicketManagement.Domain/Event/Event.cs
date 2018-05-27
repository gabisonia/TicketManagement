using System;
using TicketManagement.Domain.Event.Events;
using TicketManagement.Shared;

namespace TicketManagement.Domain.Event
{
    public class Event : AggregateRoot
    {
        public Event() { }

        public Event(string name, DateTime date, Venue venue, int seatCount)
        {
            Name = name;
            Date = date;
            Venue = venue;
            SeatCount = SeatCount;
            Raise(new EventCreated(name, venue.Name, date, Id));
        }

        public string Name { get; }
        public DateTime Date { get; }
        public Venue Venue { get; }
        public int SeatCount { get; }
    }
}
