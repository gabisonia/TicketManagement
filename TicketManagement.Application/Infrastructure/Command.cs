namespace TicketManagement.Application.Infrastructure
{
    public abstract class Command : ApplicationBase
    {
        public abstract CommandExecutionResult Execute();

        protected CommandExecutionResult Fail(params string[] errorMessages)
        {
            var result = new CommandExecutionResult
            {
                Success = false
            };

            if (errorMessages != null)
            {
                result.Errors = errorMessages;
            }

            return result;
        }

        protected CommandExecutionResult Ok(DomainOperationResult data)
        {
            var result = new CommandExecutionResult
            {
                Data = data,
                Success = true
            };

            return result;
        }
    }
}
