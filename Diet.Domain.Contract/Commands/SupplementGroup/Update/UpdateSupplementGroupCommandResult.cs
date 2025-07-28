using Diet.Domain.Contract.Commands.SupplementGroup.Update;
using Order.Framework.Core.Bus;

public record UpdateSupplementGroupCommandResult(string state, string message) : ICommandResult;
