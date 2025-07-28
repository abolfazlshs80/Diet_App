using Diet.Domain.Contract.Commands.SupplementDurationAge.Delete;
using Order.Framework.Core.Bus;

public record DeleteSupplementDurationAgeCommandResult(string state, string message) : ICommandResult;
