using System;
using TicketManagement.Domain.Event.Events;
using TicketManagement.Shared;

namespace TicketManagement.Domain.Event
{
    public class Event : AggregateRoot
    {
        public Event() { }

        public Event(string name, DateTime date, Venue venue, int seatCount,string poster, string videoUrl)
        {
            Name = name;
            Date = date;
            Venue = venue;
            SeatCount = SeatCount;
            Poster = poster;
            VideoUrl = videoUrl;
            Raise(new EventCreated(name, venue.Name, date, Id));
        }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public Venue Venue { get; private set; }
        public int SeatCount { get; private set; }
        public string Poster { get; private set; }
        public string VideoUrl { get; private set; }
    }
}
