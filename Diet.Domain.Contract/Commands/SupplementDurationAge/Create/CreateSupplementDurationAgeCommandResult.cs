using Diet.Domain.Contract.Commands.SupplementDurationAge.Create;
using Order.Framework.Core.Bus;

public record CreateSupplementDurationAgeCommandResult(string state, string message) : ICommandResult;
