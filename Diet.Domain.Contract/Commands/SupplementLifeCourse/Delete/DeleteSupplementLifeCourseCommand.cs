using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementLifeCourse.Delete;

public record DeleteSupplementLifeCourseCommand(Guid Id) : ICommand;
