using ErrorOr;
using Order.Framework.Core.Bus;
using System.Threading.Tasks;

namespace Diet.Framework.Core.Bus;

public interface IQueryHandler<TQuery, TQueryResult>
     where TQuery : IQuery
     where TQueryResult : IQueryResult
{
    Task<ErrorOr<TQueryResult>>  Handle(TQuery Query);

}
