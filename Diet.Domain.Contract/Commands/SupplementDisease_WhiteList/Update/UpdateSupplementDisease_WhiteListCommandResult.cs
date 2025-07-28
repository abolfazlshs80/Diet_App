using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;
using Order.Framework.Core.Bus;

public record UpdateSupplementDisease_WhiteListCommandResult(string state, string message) : ICommandResult;
