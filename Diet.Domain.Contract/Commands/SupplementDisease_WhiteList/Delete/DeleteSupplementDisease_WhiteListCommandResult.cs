using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Delete;
using Order.Framework.Core.Bus;

public record DeleteSupplementDisease_WhiteListCommandResult(string state, string message) : ICommandResult;
