using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
using Order.Framework.Core.Bus;

public record UpdateSupplementLifeCourseCommandResult(string state, string message) : ICommandResult;
