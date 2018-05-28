using System;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Event;

namespace TicketManagement.Application.Commands
{
    public class CreateEventCommand : Command
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string VenueName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int SeatCount { get; set; }
        public string Poster { get; set; }
        public string VideoUrl { get; set; }

        public override CommandExecutionResult Execute()
        {
            var @event = new Event(EventName, EventDate, new Venue(VenueName, Longitude, Latitude), SeatCount, Poster, VideoUrl);

            _db.Set<Event>().Add(@event);

            _unitOfWork.Save();

            return Ok(DomainOperationResult.CreateEmpty());
        }
    }
}
