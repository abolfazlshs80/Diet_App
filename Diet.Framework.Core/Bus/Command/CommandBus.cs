

using ErrorOr;
using Order.Framework.Core.Decorator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Order.Framework.Core.Bus;
using Diet.Framework.Core.Errors;

namespace Diet.Framework.Core.Bus;


public class CommandBus : ICommandBus
{
    IServiceProvider serviceProvider;

    public CommandBus(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task<ErrorOr<TCommandResult>> Send<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand
        where TCommandResult : ICommandResult
    {
        var handler = new ValidationCommandHandlerDecorator<TCommand, TCommandResult>(serviceProvider.GetService<ICommandHandler<TCommand, TCommandResult>>()!, serviceProvider);
        if (handler is not null)
        {
            var commandResult = await handler.Handle(command);
            if (commandResult.IsError)
                return commandResult.FirstError;

            return commandResult.Value;
        }

        return BusErrors.Command.ICommandHandlerIsNull;
    }
}

