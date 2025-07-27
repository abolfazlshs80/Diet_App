using Diet.Application.Interface;
using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Commands.Create;

public class CreateRecommendationDisease_WhiteListCommandHandler : ICommandHandler<CreateRecommendationDisease_WhiteListCommand, CreateRecommendationDisease_WhiteListCommandResult>
{
    private readonly IRecommendationDisease_WhiteListRepository _recommendationDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationDisease_WhiteListCommandHandler(IRecommendationDisease_WhiteListRepository recommendationDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDisease_WhiteListRepository = recommendationDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<CreateRecommendationDisease_WhiteListCommandResult>> Handle(CreateRecommendationDisease_WhiteListCommand command)
    {
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
