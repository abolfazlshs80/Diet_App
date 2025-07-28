using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;

public record UpdateSupplementDisease_WhiteListCommand(Guid Id, Guid SupplementId, Guid DiseaseId) : ICommand;
