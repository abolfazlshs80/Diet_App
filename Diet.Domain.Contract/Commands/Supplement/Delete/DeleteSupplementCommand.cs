using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Supplement.Delete;

public record DeleteSupplementCommand(Guid Id) : ICommand;
