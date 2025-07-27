

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseSupplementCommand(  Guid CaseId, Guid SupplementId) : ICommand;
 