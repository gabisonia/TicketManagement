using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TicketManagement.Infrastructure.Db;
using TicketManagement.Shared;

namespace TicketManagement.Infrastructure.EventDispatching
{
    public interface IHandleEvent<in T> where T : DomainEvent
    {
        void Handle(T @event, TicketManagementDbContext db);
    }

    public interface IInternalEventDispatcher<TDomainEvent>
    {
        void Dispatch(IReadOnlyList<TDomainEvent> domainEvents, TicketManagementDbContext dbContext);
    }

    public class InternalDomainEventDispatcher : IInternalEventDispatcher<DomainEvent>
    {
        private readonly IDictionary<Type, List<Type>> eventhandlerMaps =
            new Dictionary<Type, List<Type>>();
        private readonly IServiceProvider serviceProvider;

        public InternalDomainEventDispatcher(IServiceProvider serviceProvider, Assembly domainEventsAssembly,
            params Assembly[] eventHandlersAssemblies)
        {
            eventhandlerMaps = EventHandlerMapping.DomainEventHandlerMapping<IHandleEvent<DomainEvent>>(domainEventsAssembly, eventHandlersAssemblies);
            this.serviceProvider = serviceProvider;
        }

        private void Dispatch(dynamic evnt, TicketManagementDbContext dbContext)
        {
            var type = evnt.GetType();
            if (!eventhandlerMaps.ContainsKey(type))
                return;
            var @eventHandlers = eventhandlerMaps[type];
            foreach (var handlr in @eventHandlers)
            {
                var domainEventHandler = serviceProvider.GetService(handlr);
                if (domainEventHandler == null)
                {
                    domainEventHandler = Activator.CreateInstance(handlr);
                }
                var handlerInstance = domainEventHandler as dynamic;
                handlerInstance.Handle(evnt, dbContext);
            }
        }

        public void Dispatch(IReadOnlyList<DomainEvent> events, TicketManagementDbContext dbContext)
        {
            foreach (var item in events)
            {
                this.Dispatch(item, dbContext);
            }
        }
    }

    public class EventHandlerMapping
    {
        public static IDictionary<Type, List<Type>> DomainEventHandlerMapping<THandler>(Assembly domainEventsAssembly, Assembly[] eventHandlersAssembly)
        {
            IDictionary<Type, List<Type>> result =
            new Dictionary<Type, List<Type>>();

            var domainEventTypes = domainEventsAssembly.GetTypes();

            var domainEvents = domainEventTypes
                .Where(at => typeof(DomainEvent).IsAssignableFrom(at)
                 && at.IsClass && !at.IsAbstract && !at.IsInterface);

            foreach (var domainEvent in domainEvents)
            {
                result[domainEvent] = new List<Type>();
                foreach (var assemblyType in eventHandlersAssembly.SelectMany(x => x.GetTypes()))
                {
                    var eventHandlers = assemblyType.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(THandler).GetGenericTypeDefinition());

                    if (eventHandlers != null)
                    {
                        foreach (var eventHandler in eventHandlers)
                        {
                            var genericarguments = eventHandler.GetGenericArguments().FirstOrDefault(x => domainEvent == x);
                            if (genericarguments != null)
                            {
                                result[domainEvent].Add(assemblyType);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
