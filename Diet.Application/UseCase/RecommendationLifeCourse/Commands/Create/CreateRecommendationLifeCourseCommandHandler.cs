using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Commands.Create;

public class CreateRecommendationLifeCourseCommandHandler : ICommandHandler<CreateRecommendationLifeCourseCommand, CreateRecommendationLifeCourseCommandResult>
{
    private readonly IRecommendationLifeCourseRepository _recommendationLifeCourseRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly ILifeCourseRepository _lifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationLifeCourseCommandHandler(IRecommendationLifeCourseRepository recommendationLifeCourseRepository,
        IRecommendationRepository recommendationRepository,
        ILifeCourseRepository lifeCourseRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationLifeCourseRepository = recommendationLifeCourseRepository;
        _lifeCourseRepository = lifeCourseRepository;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<ErrorOr<CreateRecommendationLifeCourseCommandResult>> Handle(CreateRecommendationLifeCourseCommand command)
    {
        if (!await _lifeCourseRepository.IsExists(command.LifeCourseId))
            return new CreateRecommendationLifeCourseCommandResult("error", "LifeCourseId is not Exists");
        if (!await _recommendationRepository.IsExists(command.RecommendationId))
            return new CreateRecommendationLifeCourseCommandResult("error", "Recommendation is not Exists");

        var result = Domain.recommendationLifeCourse.RecommendationLifeCourse.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationLifeCourseRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateRecommendationLifeCourseCommandResult("error", "Add RecommendationLifeCourse has error and rollback is done");

        return new CreateRecommendationLifeCourseCommandResult("success", "ok");
    }
}
