using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementDurationAge.Update;

public record UpdateSupplementDurationAgeCommand(Guid Id, Guid SupplementId, Guid DurationAgeId) : ICommand;
