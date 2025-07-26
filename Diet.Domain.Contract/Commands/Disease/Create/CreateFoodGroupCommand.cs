

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateDiseaseCommand(string Title, Guid ParentId) : ICommand;
 