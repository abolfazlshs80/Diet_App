using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDurationAge.Commands.Delete;

public class DeleteRecommendationDurationAgeCommandHandler : ICommandHandler<DeleteRecommendationDurationAgeCommand, DeleteRecommendationDurationAgeCommandResult>
{
    private readonly IRecommendationDurationAgeRepository _RecommendationDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecommendationDurationAgeCommandHandler(IRecommendationDurationAgeRepository RecommendationDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _RecommendationDurationAgeRepository = RecommendationDurationAgeRepository;
    }

    public async Task<ErrorOr<DeleteRecommendationDurationAgeCommandResult>> Handle(DeleteRecommendationDurationAgeCommand command)
    {
        var result = await _RecommendationDurationAgeRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteRecommendationDurationAgeCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _RecommendationDurationAgeRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteRecommendationDurationAgeCommandResult("error", "delete RecommendationDurationAge has error and rollback is done");

        return new DeleteRecommendationDurationAgeCommandResult("success", "ok");
    }
}
