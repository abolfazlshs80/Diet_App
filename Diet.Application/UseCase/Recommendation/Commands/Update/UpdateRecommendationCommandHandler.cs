using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Recommendation.Update;
using Diet.Domain.recommendation.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Recommendation.Commands.Update;

public class UpdateRecommendationCommandHandler : ICommandHandler<UpdateRecommendationCommand, UpdateRecommendationCommandResult>
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecommendationCommandHandler(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<ErrorOr<UpdateRecommendationCommandResult>> Handle(UpdateRecommendationCommand command)
    {
        var recommendation = await _recommendationRepository.ByIdAsync(command.Id);
        if (recommendation == null)
            return new UpdateRecommendationCommandResult("error", "not found recommendation");

        var result = Domain.recommendation.Recommendation.Update(recommendation, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateRecommendationCommandResult("error", "Update Recommendation has error and rollback is done");

        return new UpdateRecommendationCommandResult("success", "ok");
    }
}
