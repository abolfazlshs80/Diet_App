using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseDrugCommandResult(string state, string message) : ICommandResult;
