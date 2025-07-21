

using ErrorOr;
using Order.Framework.Core.Decorator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Order.Framework.Core.Bus;
using Diet.Framework.Core.Errors;

namespace Diet.Framework.Core.Bus;


public class QueryBus : IQueryBus
{
    IServiceProvider serviceProvider;

    public QueryBus(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task<ErrorOr<TQueryResult>> Send<TQuery, TQueryResult>(TQuery Query)
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
        var handler = new ValidationQueryHandlerDecorator<TQuery, TQueryResult>(serviceProvider.GetService<IQueryHandler<TQuery, TQueryResult>>()!, serviceProvider);
        if (handler is not null)
        {
            var QueryResult = await handler.Handle(Query);
            if (QueryResult.IsError)
                return QueryResult.FirstError;

            return QueryResult.Value;
        }

        return BusErrors.Query.IQueryHandlerIsNull;
    }
}

