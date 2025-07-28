using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementDurationAge.Delete;

public record DeleteSupplementDurationAgeCommand(Guid Id) : ICommand;
