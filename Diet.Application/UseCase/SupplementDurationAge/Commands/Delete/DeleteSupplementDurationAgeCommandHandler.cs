using Diet.Domain.supplementDurationAge.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDurationAge.Commands.Delete;

public class DeleteSupplementDurationAgeCommandHandler : ICommandHandler<DeleteSupplementDurationAgeCommand, DeleteSupplementDurationAgeCommandResult>
{
    private readonly ISupplementDurationAgeRepository _SupplementDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSupplementDurationAgeCommandHandler(ISupplementDurationAgeRepository SupplementDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _SupplementDurationAgeRepository = SupplementDurationAgeRepository;
    }

    public async Task<ErrorOr<DeleteSupplementDurationAgeCommandResult>> Handle(DeleteSupplementDurationAgeCommand command)
    {
        var result = await _SupplementDurationAgeRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteSupplementDurationAgeCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _SupplementDurationAgeRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteSupplementDurationAgeCommandResult("error", "delete SupplementDurationAge has error and rollback is done");

        return new DeleteSupplementDurationAgeCommandResult("success", "ok");
    }
}
