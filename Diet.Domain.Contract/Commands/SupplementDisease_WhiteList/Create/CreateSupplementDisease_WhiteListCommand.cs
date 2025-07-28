using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;

public record CreateSupplementDisease_WhiteListCommand(Guid SupplementId, Guid DiseaseId) : ICommand;
