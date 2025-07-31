using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Commands.Update;

public class UpdateRecommendationLifeCourseCommandHandler : ICommandHandler<UpdateRecommendationLifeCourseCommand, UpdateRecommendationLifeCourseCommandResult>
{
    private readonly IRecommendationLifeCourseRepository _recommendationLifeCourseRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly ILifeCourseRepository _lifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecommendationLifeCourseCommandHandler(IRecommendationLifeCourseRepository recommendationLifeCourseRepository,
        IRecommendationRepository recommendationRepository,
        ILifeCourseRepository lifeCourseRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationLifeCourseRepository = recommendationLifeCourseRepository;
        _lifeCourseRepository = lifeCourseRepository;
        _recommendationRepository = recommendationRepository;
    }


    public async Task<ErrorOr<UpdateRecommendationLifeCourseCommandResult>> Handle(UpdateRecommendationLifeCourseCommand command)
    {
        if (!await _lifeCourseRepository.IsExists(command.LifeCourseId))
            return new UpdateRecommendationLifeCourseCommandResult("error", "LifeCourseId is not Exists");
        if (!await _recommendationRepository.IsExists(command.RecommendationId))
            return new UpdateRecommendationLifeCourseCommandResult("error", "Recommendation is not Exists");

        var recommendationLifeCourse = await _recommendationLifeCourseRepository.ByIdAsync(command.Id);
        if (recommendationLifeCourse == null)
            return new UpdateRecommendationLifeCourseCommandResult("error", "not found recommendationlifecourse");

        var result = Domain.recommendationLifeCourse.RecommendationLifeCourse.Update(recommendationLifeCourse, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _recommendationLifeCourseRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateRecommendationLifeCourseCommandResult("error", "Update RecommendationLifeCourse has error and rollback is done");

        return new UpdateRecommendationLifeCourseCommandResult("success", "ok");
    }
}
