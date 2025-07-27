using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;

public record CreateRecommendationLifeCourseCommand(Guid RecommendationId, Guid LifeCourseId) : ICommand;
