using Diet.Application.Interface;
using Diet.Domain.supplement.Repository;
using Diet.Domain.Contract.Commands.Supplement.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Supplement.Commands.Create;

public class CreateSupplementCommandHandler : ICommandHandler<CreateSupplementCommand, CreateSupplementCommandResult>
{
    private readonly ISupplementRepository _supplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementCommandHandler(ISupplementRepository supplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementRepository = supplementRepository;
    }

    public async Task<ErrorOr<CreateSupplementCommandResult>> Handle(CreateSupplementCommand command)
    {
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
