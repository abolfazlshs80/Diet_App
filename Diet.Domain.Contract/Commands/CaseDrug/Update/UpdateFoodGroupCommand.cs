

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseDrugCommand(Guid Id, Guid CaseId, Guid DrugId) : ICommand;
 