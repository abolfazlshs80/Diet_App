using Diet.Domain.Contract.Commands.SupplementLifeCourse.Delete;
using Order.Framework.Core.Bus;

public record DeleteSupplementLifeCourseCommandResult(string state, string message) : ICommandResult;
