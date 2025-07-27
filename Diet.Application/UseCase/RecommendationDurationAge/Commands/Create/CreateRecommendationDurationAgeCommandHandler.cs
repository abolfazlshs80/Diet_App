using Diet.Application.Interface;
using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.RecommendationDurationAge.Commands.Create;

public class CreateRecommendationDurationAgeCommandHandler : ICommandHandler<CreateRecommendationDurationAgeCommand, CreateRecommendationDurationAgeCommandResult>
{
    private readonly IRecommendationDurationAgeRepository _recommendationDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecommendationDurationAgeCommandHandler(IRecommendationDurationAgeRepository recommendationDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDurationAgeRepository = recommendationDurationAgeRepository;
    }

    public async Task<ErrorOr<CreateRecommendationDurationAgeCommandResult>> Handle(CreateRecommendationDurationAgeCommand command)
    {
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
