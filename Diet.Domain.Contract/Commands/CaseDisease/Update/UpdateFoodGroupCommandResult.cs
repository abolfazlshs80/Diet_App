using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseDiseaseCommandResult(string state, string message) : ICommandResult;
