

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateLifeCourseCommand(string Title, Guid ParentId) : ICommand;
 