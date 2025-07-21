using ErrorOr;
using Order.Framework.Core.Bus;
using System.Threading.Tasks;

namespace Diet.Framework.Core.Bus;

public interface ICommandBus
{
    Task<ErrorOr<TCommandResult>> Send<TCommand, TCommandResult>(TCommand command)
         where TCommand : ICommand
         where TCommandResult : ICommandResult
        ;

}
