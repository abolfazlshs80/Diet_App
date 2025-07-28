using Diet.Domain.Contract.Commands.Supplement.Create;
using Order.Framework.Core.Bus;

public record CreateSupplementCommandResult(string state, string message) : ICommandResult;
