using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
using Order.Framework.Core.Bus;

public record CreateSupplementLifeCourseCommandResult(string state, string message) : ICommandResult;
