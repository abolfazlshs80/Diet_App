using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Delete;
using Order.Framework.Core.Bus;

public record DeleteRecommendationLifeCourseCommandResult(string state, string message) : ICommandResult;
