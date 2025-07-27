using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteCaseFoodStuffAllergyCommandResult(string state, string message) : ICommandResult;
