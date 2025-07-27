using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
using Diet.Application.Interface;
using Diet.Domain.recommendationDurationAge.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDurationAge.Commands.Update;

public class UpdateRecommendationDurationAgeCommandHandler : ICommandHandler<UpdateRecommendationDurationAgeCommand, UpdateRecommendationDurationAgeCommandResult>
{
    private readonly IRecommendationDurationAgeRepository _recommendationDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecommendationDurationAgeCommandHandler(IRecommendationDurationAgeRepository recommendationDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDurationAgeRepository = recommendationDurationAgeRepository;
    }

    public async Task<ErrorOr<UpdateRecommendationDurationAgeCommandResult>> Handle(UpdateRecommendationDurationAgeCommand command)
    {
        var recommendationDurationAge = await _recommendationDurationAgeRepository.ByIdAsync(command.Id);
        if (recommendationDurationAge == null)
            return new UpdateRecommendationDurationAgeCommandResult("error", "not found recommendationdurationage");

        var result = Domain.recommendationDurationAge.RecommendationDurationAge.Update(recommendationDurationAge, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationDurationAgeRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateRecommendationDurationAgeCommandResult("error", "Update RecommendationDurationAge has error and rollback is done");

        return new UpdateRecommendationDurationAgeCommandResult("success", "ok");
    }
}
