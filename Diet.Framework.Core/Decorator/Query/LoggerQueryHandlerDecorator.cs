

using Diet.Framework.Core.Bus;
using ErrorOr;
using Order.Framework.Core.Bus;
using System;
using System.Threading.Tasks;

namespace Order.Framework.Core.Decorator;

public class LoggerQueryHandlerDecorator<TQuery, TQueryResult>
      : IQueryHandler<TQuery, TQueryResult>
       where TQuery : IQuery
       where TQueryResult : IQueryResult
{
    IServiceProvider serviceProvider;
    private readonly IQueryHandler<TQuery, TQueryResult> _handler;

    public LoggerQueryHandlerDecorator(
        IQueryHandler<TQuery, TQueryResult> handler,
        IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        _handler = handler;
    }

    public async Task<ErrorOr<TQueryResult>> Handle(TQuery Query)
    {
        Console.WriteLine("log " + Query.GetType().ToString());
        return await _handler.Handle(Query);

    }

}


