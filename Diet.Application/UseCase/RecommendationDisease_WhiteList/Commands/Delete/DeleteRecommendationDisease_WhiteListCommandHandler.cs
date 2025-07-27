using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Commands.Delete;

public class DeleteRecommendationDisease_WhiteListCommandHandler : ICommandHandler<DeleteRecommendationDisease_WhiteListCommand, DeleteRecommendationDisease_WhiteListCommandResult>
{
    private readonly IRecommendationDisease_WhiteListRepository _RecommendationDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecommendationDisease_WhiteListCommandHandler(IRecommendationDisease_WhiteListRepository RecommendationDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _RecommendationDisease_WhiteListRepository = RecommendationDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<DeleteRecommendationDisease_WhiteListCommandResult>> Handle(DeleteRecommendationDisease_WhiteListCommand command)
    {
        var result = await _RecommendationDisease_WhiteListRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteRecommendationDisease_WhiteListCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
        await _RecommendationDisease_WhiteListRepository.DeleteAsync(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteRecommendationDisease_WhiteListCommandResult("error", "delete RecommendationDisease_WhiteList has error and rollback is done");

        return new DeleteRecommendationDisease_WhiteListCommandResult("success", "ok");
    }
}
