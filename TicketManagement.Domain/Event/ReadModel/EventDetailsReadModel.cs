using System;

namespace TicketManagement.Domain.Event.ReadModel
{
    public class EventDetailsReadModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string VenueName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int SeatCount { get; set; }
        public string Poster { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
    }
}
