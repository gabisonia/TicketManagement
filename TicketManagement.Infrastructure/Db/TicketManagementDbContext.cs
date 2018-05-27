using Microsoft.EntityFrameworkCore;
using System.Linq;
using TicketManagement.Infrastructure.EventDispatching;
using TicketManagement.Shared;

namespace TicketManagement.Infrastructure.Db
{
    public class TicketManagementDbContext : DbContext
    {
        public TicketManagementDbContext(DbContextOptions<TicketManagementDbContext> options) : base(options)
        {

        }
    }

    public class UnitOfWork
    {
        private readonly TicketManagementDbContext _ticketManagementDbContext;
        private readonly InternalDomainEventDispatcher _internalDomainEventDispatcher;

        public UnitOfWork(TicketManagementDbContext kritosaurusDbContext, InternalDomainEventDispatcher internalDomainEventDispatcher)
        {
            this._ticketManagementDbContext = kritosaurusDbContext;
            this._internalDomainEventDispatcher = internalDomainEventDispatcher;
        }

        public void Save()
        {
            using (var transaction = _ticketManagementDbContext.Database.BeginTransaction())
            {
                var modifiedEntries = _ticketManagementDbContext.ChangeTracker.Entries<IHasDomainEvents>().ToList();
                _ticketManagementDbContext.SaveChanges();

                foreach (var entry in modifiedEntries)
                {
                    var events = entry.Entity.UncommittedChanges();
                    if (events.Any())
                    {
                        _internalDomainEventDispatcher.Dispatch(events, _ticketManagementDbContext);
                        entry.Entity.MarkChangesAsCommitted();
                    }
                }

                _ticketManagementDbContext.SaveChanges();
                transaction.Commit();
            }
        }
    }
}
