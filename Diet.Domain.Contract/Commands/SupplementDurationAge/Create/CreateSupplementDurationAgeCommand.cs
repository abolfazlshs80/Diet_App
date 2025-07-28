using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementDurationAge.Create;

public record CreateSupplementDurationAgeCommand(Guid SupplementId, Guid DurationAgeId) : ICommand;
