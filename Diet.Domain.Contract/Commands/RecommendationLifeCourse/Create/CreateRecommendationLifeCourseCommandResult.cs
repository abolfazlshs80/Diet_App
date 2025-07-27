using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
using Order.Framework.Core.Bus;

public record CreateRecommendationLifeCourseCommandResult(string state, string message) : ICommandResult;
