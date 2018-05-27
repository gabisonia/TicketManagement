using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TicketManagement.Shared
{
    public abstract class AggregateRoot : IHasDomainEvents
    {
        public int Id { get; set; }
        private IList<DomainEvent> _events { get; } = new List<DomainEvent>();

        IReadOnlyList<DomainEvent> IHasDomainEvents.UncommittedChanges() => new ReadOnlyCollection<DomainEvent>(_events);

        void IHasDomainEvents.MarkChangesAsCommitted() => _events.Clear();

        void IHasDomainEvents.Raise(DomainEvent evnt) => _events.Add(evnt);

        protected void Raise(DomainEvent evnt)
        {
            evnt.AggregateRootId = Id;
            evnt.OccuredOn = DateTime.Now;
            evnt.EventType = evnt.GetType().Name;
            (this as IHasDomainEvents).Raise(evnt);
        }

        bool IHasDomainEvents.NewlyCreated() => _events.Any(x => x is ICreateEvent);
    }
}
