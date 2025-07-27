using Diet.Application.Interface;
using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Commands.Create;

public class CreateRecommendationLifeCourseCommandHandler : ICommandHandler<CreateRecommendationLifeCourseCommand, CreateRecommendationLifeCourseCommandResult>
{
    private readonly IRecommendationLifeCourseRepository _recommendationLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationLifeCourseCommandHandler(IRecommendationLifeCourseRepository recommendationLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationLifeCourseRepository = recommendationLifeCourseRepository;
    }

    public async Task<ErrorOr<CreateRecommendationLifeCourseCommandResult>> Handle(CreateRecommendationLifeCourseCommand command)
    {
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
