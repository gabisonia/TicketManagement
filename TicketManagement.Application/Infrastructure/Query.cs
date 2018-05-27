namespace TicketManagement.Application.Infrastructure
{
    public abstract class Query<TQueryResult> : ApplicationBase where TQueryResult : class
    {
        public abstract QueryExecutionResult<TQueryResult> Execute();

        protected QueryExecutionResult<TQueryResult> Fail(params string[] errorMessages)
        {
            var result = new QueryExecutionResult<TQueryResult>
            {
                Success = false
            };

            if (errorMessages != null)
            {
                result.Errors = errorMessages;
            }

            return result;
        }

        protected QueryExecutionResult<TQueryResult> Ok(TQueryResult data)
        {
            var result = new QueryExecutionResult<TQueryResult>
            {
                Data = data,
                Success = true
            };

            return result;
        }
    }
}
