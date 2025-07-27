using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationLifeCourse.Delete;

public record DeleteRecommendationLifeCourseCommand(Guid Id) : ICommand;
