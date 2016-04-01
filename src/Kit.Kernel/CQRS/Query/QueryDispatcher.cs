using System;

namespace Kit.Kernel.CQRS.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IQueryResult
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var handler = _serviceProvider.GetService<IQueryHandler<TParameter, TResult>>();
            return (handler != null) ? handler.Execute(query) : default(TResult);
        }
    }
}