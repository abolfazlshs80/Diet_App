using ErrorOr;
using Order.Framework.Core.Bus;
using System.Threading.Tasks;

namespace Diet.Framework.Core.Bus;

public interface IQueryBus
{
    Task<ErrorOr<TQueryResult>> Send<TQuery, TQueryResult>(TQuery Query)
         where TQuery : IQuery
         where TQueryResult : IQueryResult
        ;

}
