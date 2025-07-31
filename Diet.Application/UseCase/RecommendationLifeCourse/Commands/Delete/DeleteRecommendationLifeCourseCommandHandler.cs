using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Commands.Delete;

public class DeleteRecommendationLifeCourseCommandHandler : ICommandHandler<DeleteRecommendationLifeCourseCommand, DeleteRecommendationLifeCourseCommandResult>
{
    private readonly IRecommendationLifeCourseRepository _RecommendationLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecommendationLifeCourseCommandHandler(IRecommendationLifeCourseRepository RecommendationLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _RecommendationLifeCourseRepository = RecommendationLifeCourseRepository;
    }

    public async Task<ErrorOr<DeleteRecommendationLifeCourseCommandResult>> Handle(DeleteRecommendationLifeCourseCommand command)
    {
        var result = await _RecommendationLifeCourseRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteRecommendationLifeCourseCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _RecommendationLifeCourseRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteRecommendationLifeCourseCommandResult("error", "delete RecommendationLifeCourse has error and rollback is done");

        return new DeleteRecommendationLifeCourseCommandResult("success", "ok");
    }
}
