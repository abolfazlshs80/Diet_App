

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseDiseaseCommand(  Guid CaseId, Guid DiseaseId) : ICommand;
 