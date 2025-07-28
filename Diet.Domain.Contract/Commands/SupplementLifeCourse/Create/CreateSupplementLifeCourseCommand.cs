using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;

public record CreateSupplementLifeCourseCommand(Guid SupplementId, Guid LifeCourseId) : ICommand;
