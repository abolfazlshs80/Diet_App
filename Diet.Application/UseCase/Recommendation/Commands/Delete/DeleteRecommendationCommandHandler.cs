using Diet.Domain.recommendation.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Commands.Recommendation.Delete;

namespace Diet.Application.UseCase.Recommendation.Commands.Delete;

public class DeleteRecommendationCommandHandler : ICommandHandler<DeleteRecommendationCommand, DeleteRecommendationCommandResult>
{
    private readonly IRecommendationRepository _RecommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecommendationCommandHandler(IRecommendationRepository RecommendationRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _RecommendationRepository = RecommendationRepository;
    }

    public async Task<ErrorOr<DeleteRecommendationCommandResult>> Handle(DeleteRecommendationCommand command)
    {
        var result = await _RecommendationRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteRecommendationCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
        await _RecommendationRepository.DeleteAsync(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteRecommendationCommandResult("error", "delete Recommendation has error and rollback is done");

        return new DeleteRecommendationCommandResult("success", "ok");
    }
}
