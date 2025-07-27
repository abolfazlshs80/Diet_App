

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateCaseSupplementCommand(Guid Id, Guid CaseId, Guid SupplementId) : ICommand;
 