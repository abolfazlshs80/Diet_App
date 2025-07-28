using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Commands.Create;

public class CreateRecommendationDisease_WhiteListCommandHandler : ICommandHandler<CreateRecommendationDisease_WhiteListCommand, CreateRecommendationDisease_WhiteListCommandResult>
{
    private readonly IRecommendationDisease_WhiteListRepository _recommendationDisease_WhiteListRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IDiseaseRepository _diseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationDisease_WhiteListCommandHandler(IRecommendationDisease_WhiteListRepository recommendationDisease_WhiteListRepository,
        IRecommendationRepository recommendationRepository
        , IDiseaseRepository diseaseRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDisease_WhiteListRepository = recommendationDisease_WhiteListRepository;
        _recommendationRepository = recommendationRepository;
        _diseaseRepository = diseaseRepository;
    }

    public async Task<ErrorOr<CreateRecommendationDisease_WhiteListCommandResult>> Handle(CreateRecommendationDisease_WhiteListCommand command)
    {
        if (!await _diseaseRepository.IsExists(command.DiseaseId))
            return new CreateRecommendationDisease_WhiteListCommandResult("error", "Disease is not Exists");
        if (!await _recommendationRepository.IsExists(command.RecommendationId))
            return new CreateRecommendationDisease_WhiteListCommandResult("error", "Recommendation is not Exists");


        var result = Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationDisease_WhiteListRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateRecommendationDisease_WhiteListCommandResult("error", "Add RecommendationDisease_WhiteList has error and rollback is done");

        return new CreateRecommendationDisease_WhiteListCommandResult("success", "ok");
    }
}
