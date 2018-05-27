using System;
using TicketManagement.Infrastructure.Db;

namespace TicketManagement.Application.Infrastructure
{
    public class QueryExecutor
    {
        private readonly TicketManagementDbContext _db;
        private UnitOfWork _unitOfWork;

        public QueryExecutor(TicketManagementDbContext db, UnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public QueryExecutionResult<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : Query<TResult> where TResult : class
        {
            try
            {
                query.Resolve(_db, _unitOfWork);

                return query.Execute();
            }
            catch (Exception ex)
            {
                return new QueryExecutionResult<TResult>
                {
                    Success = false
                };
            }
        }
    }
}
