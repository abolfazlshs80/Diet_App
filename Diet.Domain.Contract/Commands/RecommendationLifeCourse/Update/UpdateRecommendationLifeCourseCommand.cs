using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;

public record UpdateRecommendationLifeCourseCommand(Guid Id, Guid RecommendationId, Guid LifeCourseId) : ICommand;
