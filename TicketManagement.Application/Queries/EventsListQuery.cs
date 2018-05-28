using System;
using System.Collections.Generic;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Event.ReadModel;
using System.Linq;

namespace TicketManagement.Application.Queries
{
    public class EventsListQuery : Query<EventsListQueryResult>
    {
        public override QueryExecutionResult<EventsListQueryResult> Execute()
        {
            var events = from evnt in _db.Set<EventsListReadModel>()
                         select new EventsListQueryResult.Event
                         {
                             Date = evnt.Date,
                             Id = evnt.EventId,
                             Name = evnt.Name,
                             VenueName = evnt.VenueName
                         };

            return Ok(new EventsListQueryResult() { Events = events.ToList() });
        }
    }

    public class EventsListQueryResult
    {
        public IEnumerable<Event> Events { get; set; }

        public class Event
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string VenueName { get; set; }
            public bool IsSoldOut { get; set; }
        }
    }
}
