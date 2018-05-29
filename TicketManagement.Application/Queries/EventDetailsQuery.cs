using System;
using System.Linq;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Event.ReadModel;

namespace TicketManagement.Application.Queries
{
    public class EventDetailsQuery : Query<EventDetailsQueryResult>
    {
        public int Id { get; set; }

        public override QueryExecutionResult<EventDetailsQueryResult> Execute()
        {
            var evnt = _db.Set<EventDetailsReadModel>().FirstOrDefault(x => x.EventId == Id);

            if (evnt.IsNull())
                return Fail("Event Not Found");

            return Ok(new EventDetailsQueryResult()
            {
                Date = evnt.Date,
                Description = evnt.Description,
                Id = evnt.EventId,
                Latitude = evnt.Latitude,
                Longitude = evnt.Longitude,
                Name = evnt.Name,
                Poster = evnt.Poster,
                SeatCount = evnt.SeatCount,
                VenueName = evnt.VenueName,
                VideoUrl = evnt.VideoUrl
            });
        }
    }

    public class EventDetailsQueryResult
    {
        public int Id { get; set; }
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
