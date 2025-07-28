using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Delete;

public record DeleteSupplementDisease_WhiteListCommand(Guid Id) : ICommand;
