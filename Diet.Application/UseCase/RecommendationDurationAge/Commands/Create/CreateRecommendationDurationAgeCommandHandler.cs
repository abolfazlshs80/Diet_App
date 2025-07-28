using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Diet.Framework.Core.Errors.BusErrors;

namespace Diet.Application.UseCase.RecommendationDurationAge.Commands.Create;

public class CreateRecommendationDurationAgeCommandHandler : ICommandHandler<CreateRecommendationDurationAgeCommand, CreateRecommendationDurationAgeCommandResult>
{
    private readonly IRecommendationDurationAgeRepository _recommendationDurationAgeRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IDurationAgeRepository _durationAgeRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationDurationAgeCommandHandler(IRecommendationDurationAgeRepository recommendationDurationAgeRepository, IUnitOfWork unitOfWork
        , IDurationAgeRepository durationAgeRepository
        , IRecommendationRepository recommendationRepository)
    {
        _unitOfWork = unitOfWork;
        _recommendationDurationAgeRepository = recommendationDurationAgeRepository;

        _recommendationRepository = recommendationRepository;
        _durationAgeRepository = durationAgeRepository;
    }

    public async Task<ErrorOr<CreateRecommendationDurationAgeCommandResult>> Handle(CreateRecommendationDurationAgeCommand command)
    {
        if (!await _durationAgeRepository.IsExists(command.DurationAgeId))
            return new CreateRecommendationDurationAgeCommandResult("error", "DurationAgeId is not Exists");
        if (!await _recommendationRepository.IsExists(command.RecommendationId))
            return new CreateRecommendationDurationAgeCommandResult("error", "Recommendation is not Exists");


        var result = Domain.recommendationDurationAge.RecommendationDurationAge.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationDurationAgeRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateRecommendationDurationAgeCommandResult("error", "Add RecommendationDurationAge has error and rollback is done");

        return new CreateRecommendationDurationAgeCommandResult("success", "ok");
    }
}
