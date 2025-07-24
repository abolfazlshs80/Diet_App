

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Update;

public record UpdateLifeCourseCommand(Guid Id,string Title, Guid ParentId) : ICommand;
 