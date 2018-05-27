using System;
using System.Collections.Generic;

namespace TicketManagement.Shared
{
    public class DomainEvent
    {
        public int AggregateRootId { get; set; }
        public DateTime OccuredOn { get; set; }
        public string EventType { get; set; }
    }

    public interface ICreateEvent { }

    public interface IHasDomainEvents
    {
        IReadOnlyList<DomainEvent> UncommittedChanges();

        void MarkChangesAsCommitted();

        void Raise(DomainEvent evnt);

        bool NewlyCreated();
    }
}
