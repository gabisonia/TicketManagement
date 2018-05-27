using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketManagement.Application.Infrastructure
{
    public class ExecutionResult
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DomainOperationResult Data { get; set; }
    }
    public class CommandExecutionResult : ExecutionResult
    {

    }

    public class QueryExecutionResult<T>
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Data { get; set; }
    }

    public class DomainOperationResult
    {
        public DomainOperationResult()
        {
        }

        [JsonConstructor]
        public DomainOperationResult(int id)
        {
            Id = id;
        }
        public int Id { get; }

        public static DomainOperationResult Create(int id) => new DomainOperationResult(id);

        public static DomainOperationResult CreateEmpty() => new DomainOperationResult();
    }
}
