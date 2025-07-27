using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
using Diet.Application.Interface;
using Diet.Domain.recommendationLifeCourse.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Commands.Update;

public class UpdateRecommendationLifeCourseCommandHandler : ICommandHandler<UpdateRecommendationLifeCourseCommand, UpdateRecommendationLifeCourseCommandResult>
{
    private readonly IRecommendationLifeCourseRepository _recommendationLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecommendationLifeCourseCommandHandler(IRecommendationLifeCourseRepository recommendationLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationLifeCourseRepository = recommendationLifeCourseRepository;
    }

    public async Task<ErrorOr<UpdateRecommendationLifeCourseCommandResult>> Handle(UpdateRecommendationLifeCourseCommand command)
    {
        var recommendationLifeCourse = await _recommendationLifeCourseRepository.ByIdAsync(command.Id);
        if (recommendationLifeCourse == null)
            return new UpdateRecommendationLifeCourseCommandResult("error", "not found recommendationlifecourse");

        var result = Domain.recommendationLifeCourse.RecommendationLifeCourse.Update(recommendationLifeCourse, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationLifeCourseRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateRecommendationLifeCourseCommandResult("error", "Update RecommendationLifeCourse has error and rollback is done");

        return new UpdateRecommendationLifeCourseCommandResult("success", "ok");
    }
}
