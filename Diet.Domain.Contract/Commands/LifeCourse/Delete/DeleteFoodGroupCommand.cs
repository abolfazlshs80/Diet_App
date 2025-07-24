

using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Delete;

public record DeleteLifeCourseCommand(Guid Id) : ICommand;
 