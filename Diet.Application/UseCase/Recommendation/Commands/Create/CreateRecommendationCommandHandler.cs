using Diet.Application.Interface;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.Contract.Commands.Recommendation.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Recommendation.Commands.Create;

public class CreateRecommendationCommandHandler : ICommandHandler<CreateRecommendationCommand, CreateRecommendationCommandResult>
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationCommandHandler(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<ErrorOr<CreateRecommendationCommandResult>> Handle(CreateRecommendationCommand command)
    {
        var result = Domain.recommendation.Recommendation.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _recommendationRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateRecommendationCommandResult("error", "Add Recommendation has error and rollback is done");

        return new CreateRecommendationCommandResult("success", "ok");
    }
}
