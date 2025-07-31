using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDurationAge.Commands.Update;

public class UpdateRecommendationDurationAgeCommandHandler : ICommandHandler<UpdateRecommendationDurationAgeCommand, UpdateRecommendationDurationAgeCommandResult>
{
    private readonly IRecommendationDurationAgeRepository _recommendationDurationAgeRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IDurationAgeRepository _durationAgeRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecommendationDurationAgeCommandHandler(IRecommendationDurationAgeRepository recommendationDurationAgeRepository, IUnitOfWork unitOfWork
        , IDurationAgeRepository durationAgeRepository
        , IRecommendationRepository recommendationRepository)
    {
        _unitOfWork = unitOfWork;
        _recommendationDurationAgeRepository = recommendationDurationAgeRepository;

        _recommendationRepository = recommendationRepository;
        _durationAgeRepository = durationAgeRepository;
    }
    public async Task<ErrorOr<UpdateRecommendationDurationAgeCommandResult>> Handle(UpdateRecommendationDurationAgeCommand command)
    {
        {
            if (!await _durationAgeRepository.IsExists(command.DurationAgeId))
                return new UpdateRecommendationDurationAgeCommandResult("error", "DurationAgeId is not Exists");
            if (!await _recommendationRepository.IsExists(command.RecommendationId))
                return new UpdateRecommendationDurationAgeCommandResult("error", "Recommendation is not Exists");


            var recommendationDurationAge = await _recommendationDurationAgeRepository.ByIdAsync(command.Id);
            if (recommendationDurationAge == null)
                return new UpdateRecommendationDurationAgeCommandResult("error", "not found recommendationdurationage");

            var result = Domain.recommendationDurationAge.RecommendationDurationAge.Update(recommendationDurationAge, command);
            if (result.IsError)
                return result.FirstError;

            await _unitOfWork.BeginTransactionAsync();
             _recommendationDurationAgeRepository.Update(result.Value);

            var commitState = await _unitOfWork.CommitAsync();
            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateRecommendationDurationAgeCommandResult("error", "Update RecommendationDurationAge has error and rollback is done");

            return new UpdateRecommendationDurationAgeCommandResult("success", "ok");
        }
    }
}