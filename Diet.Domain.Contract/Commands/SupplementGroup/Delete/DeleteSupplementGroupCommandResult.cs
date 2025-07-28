using Diet.Domain.Contract.Commands.SupplementGroup.Delete;
using Order.Framework.Core.Bus;

public record DeleteSupplementGroupCommandResult(string state, string message) : ICommandResult;
