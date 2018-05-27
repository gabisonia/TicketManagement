using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Application.Queries
{
    public class EventsListQuery : Query<EventsListQueryResult>
    {
        public override QueryExecutionResult<EventsListQueryResult> Execute()
        {
            throw new System.NotImplementedException();
        }
    }

    public class EventsListQueryResult
    {
    }
}
