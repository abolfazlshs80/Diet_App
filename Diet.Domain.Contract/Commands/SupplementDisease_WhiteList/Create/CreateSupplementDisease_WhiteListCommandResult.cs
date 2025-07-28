using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;
using Order.Framework.Core.Bus;

public record CreateSupplementDisease_WhiteListCommandResult(string state, string message) : ICommandResult;
