using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
using Order.Framework.Core.Bus;

public record UpdateSupplementDurationAgeCommandResult(string state, string message) : ICommandResult;
