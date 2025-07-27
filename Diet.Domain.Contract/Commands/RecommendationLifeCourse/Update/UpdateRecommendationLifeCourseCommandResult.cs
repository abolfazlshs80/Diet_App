using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
using Order.Framework.Core.Bus;

public record UpdateRecommendationLifeCourseCommandResult(string state, string message) : ICommandResult;
