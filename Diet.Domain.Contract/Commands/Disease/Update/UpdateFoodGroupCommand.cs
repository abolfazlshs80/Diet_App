

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateDiseaseCommand(Guid Id,string Title, Guid ParentId) : ICommand;
 