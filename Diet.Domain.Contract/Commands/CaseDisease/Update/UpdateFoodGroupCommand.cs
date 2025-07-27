

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseDiseaseCommand(Guid Id, Guid CaseId, Guid DiseaseId) : ICommand;
 