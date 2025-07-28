using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Supplement.Create;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementGroup.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Supplement.Commands.Create;

public class CreateSupplementCommandHandler : ICommandHandler<CreateSupplementCommand, CreateSupplementCommandResult>
{
    private readonly ISupplementRepository _supplementRepository;
    private readonly ISupplementGroupRepository _supplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementCommandHandler(ISupplementRepository supplementRepository,ISupplementGroupRepository supplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementRepository = supplementRepository;
        _supplementGroupRepository = supplementGroupRepository;
    }

    public async Task<ErrorOr<CreateSupplementCommandResult>> Handle(CreateSupplementCommand command)
    {
        if (!await _supplementGroupRepository.IsExists(command.SupplementGroupId))
            return new CreateSupplementCommandResult("error", "SupplementGroupId is not Exists");
  

        var result = Domain.supplement.Supplement.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSupplementCommandResult("error", "Add Supplement has error and rollback is done");

        return new CreateSupplementCommandResult("success", "ok");
    }
}
