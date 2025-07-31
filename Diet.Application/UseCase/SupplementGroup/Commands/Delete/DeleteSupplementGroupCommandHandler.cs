using Diet.Domain.supplementGroup.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementGroup.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementGroup.Commands.Delete;

public class DeleteSupplementGroupCommandHandler : ICommandHandler<DeleteSupplementGroupCommand, DeleteSupplementGroupCommandResult>
{
    private readonly ISupplementGroupRepository _SupplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSupplementGroupCommandHandler(ISupplementGroupRepository SupplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _SupplementGroupRepository = SupplementGroupRepository;
    }

    public async Task<ErrorOr<DeleteSupplementGroupCommandResult>> Handle(DeleteSupplementGroupCommand command)
    {
        var result = await _SupplementGroupRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteSupplementGroupCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _SupplementGroupRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteSupplementGroupCommandResult("error", "delete SupplementGroup has error and rollback is done");

        return new DeleteSupplementGroupCommandResult("success", "ok");
    }
}
