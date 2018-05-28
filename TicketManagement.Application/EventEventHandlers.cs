using TicketManagement.Domain.Event.Events;
using TicketManagement.Domain.Event.ReadModel;
using TicketManagement.Infrastructure.Db;
using TicketManagement.Infrastructure.EventDispatching;

namespace TicketManagement.Application
{
    public class EventEventHandlers : IHandleEvent<EventCreated>
    {
        public void Handle(EventCreated @event, TicketManagementDbContext db)
        {
            var eventsListModel = new EventsListReadModel()
            {
                Date = @event.Event.Date,
                IsSoldOut = false,
                Name = @event.Event.Name,
                VenueName = @event.Event.Venue.Name,
                EventId = @event.Event.Id
            };

            db.Set<EventsListReadModel>().Add(eventsListModel);

            var eventDetailsModel = new EventDetailsReadModel()
            {
                Date = @event.Event.Date,
                Name = @event.Event.Name,
                VenueName = @event.Event.Venue.Name,
                EventId = @event.Event.Id,
                Latitude = @event.Event.Venue.Latitude,
                Longitude = @event.Event.Venue.Longitude,
                Poster = @event.Event.Poster,
                SeatCount = @event.Event.SeatCount,
                VideoUrl = @event.Event.VideoUrl
            };

            db.Set<EventDetailsReadModel>().Add(eventDetailsModel);
        }
    }
}
