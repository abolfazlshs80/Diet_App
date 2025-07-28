using Diet.Domain.Contract.Commands.SupplementGroup.Create;
using Order.Framework.Core.Bus;

public record CreateSupplementGroupCommandResult(string state, string message) : ICommandResult;
