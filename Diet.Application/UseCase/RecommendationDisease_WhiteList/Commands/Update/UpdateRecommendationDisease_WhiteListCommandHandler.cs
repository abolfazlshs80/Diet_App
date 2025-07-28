using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;
using Diet.Domain.disease.Repository;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Commands.Update;

public class UpdateRecommendationDisease_WhiteListCommandHandler : ICommandHandler<UpdateRecommendationDisease_WhiteListCommand, UpdateRecommendationDisease_WhiteListCommandResult>
{
    private readonly IRecommendationDisease_WhiteListRepository _recommendationDisease_WhiteListRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IDiseaseRepository _diseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecommendationDisease_WhiteListCommandHandler(IRecommendationDisease_WhiteListRepository recommendationDisease_WhiteListRepository,
        IRecommendationRepository recommendationRepository
        , IDiseaseRepository diseaseRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDisease_WhiteListRepository = recommendationDisease_WhiteListRepository;
        _recommendationRepository = recommendationRepository;
        _diseaseRepository = diseaseRepository;
    }

    public async Task<ErrorOr<UpdateRecommendationDisease_WhiteListCommandResult>> Handle(UpdateRecommendationDisease_WhiteListCommand command)
    {
        if (!await _diseaseRepository.IsExists(command.DiseaseId))
            return new UpdateRecommendationDisease_WhiteListCommandResult("error", "Disease is not Exists");
        if (!await _recommendationRepository.IsExists(command.RecommendationId))
            return new UpdateRecommendationDisease_WhiteListCommandResult("error", "Recommendation is not Exists");

        var recommendationDisease_WhiteList = await _recommendationDisease_WhiteListRepository.ByIdAsync(command.Id);
        if (recommendationDisease_WhiteList == null)
            return new UpdateRecommendationDisease_WhiteListCommandResult("error", "not found recommendationdisease_whitelist");

        var result = Domain.recommendationDisease_WhiteList.RecommendationDisease_WhiteList.Update(recommendationDisease_WhiteList, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationDisease_WhiteListRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateRecommendationDisease_WhiteListCommandResult("error", "Update RecommendationDisease_WhiteList has error and rollback is done");

        return new UpdateRecommendationDisease_WhiteListCommandResult("success", "ok");
    }
}
