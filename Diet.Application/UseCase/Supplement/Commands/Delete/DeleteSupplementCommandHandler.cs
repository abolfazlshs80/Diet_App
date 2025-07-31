using Diet.Domain.supplement.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Supplement.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Supplement.Commands.Delete;

public class DeleteSupplementCommandHandler : ICommandHandler<DeleteSupplementCommand, DeleteSupplementCommandResult>
{
    private readonly ISupplementRepository _SupplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSupplementCommandHandler(ISupplementRepository SupplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _SupplementRepository = SupplementRepository;
    }

    public async Task<ErrorOr<DeleteSupplementCommandResult>> Handle(DeleteSupplementCommand command)
    {
        var result = await _SupplementRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteSupplementCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _SupplementRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteSupplementCommandResult("error", "delete Supplement has error and rollback is done");

        return new DeleteSupplementCommandResult("success", "ok");
    }
}
