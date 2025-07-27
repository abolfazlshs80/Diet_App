

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseDrugCommand(  Guid CaseId, Guid DrugId) : ICommand;
 