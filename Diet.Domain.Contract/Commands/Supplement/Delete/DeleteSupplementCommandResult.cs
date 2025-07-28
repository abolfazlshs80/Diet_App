using Diet.Domain.Contract.Commands.Supplement.Delete;
using Order.Framework.Core.Bus;

public record DeleteSupplementCommandResult(string state, string message) : ICommandResult;
