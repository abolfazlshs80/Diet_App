using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;

public record UpdateSupplementLifeCourseCommand(Guid Id, Guid SupplementId, Guid LifeCourseId) : ICommand;
