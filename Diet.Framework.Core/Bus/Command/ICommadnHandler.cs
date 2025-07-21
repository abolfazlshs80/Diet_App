using ErrorOr;
using Order.Framework.Core.Bus;
using System.Threading.Tasks;

namespace Diet.Framework.Core.Bus;

public interface ICommandHandler<TCommand, TCommandResult>
     where TCommand : ICommand
     where TCommandResult : ICommandResult
{
    Task<ErrorOr<TCommandResult>>  Handle(TCommand command);

}
