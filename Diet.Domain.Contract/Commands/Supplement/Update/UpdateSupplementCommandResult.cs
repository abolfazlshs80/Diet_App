using Diet.Domain.Contract.Commands.Supplement.Update;
using Order.Framework.Core.Bus;

public record UpdateSupplementCommandResult(string state, string message) : ICommandResult;
