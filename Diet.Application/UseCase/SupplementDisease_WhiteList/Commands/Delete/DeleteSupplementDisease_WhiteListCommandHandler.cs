using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Commands.Delete;

public class DeleteSupplementDisease_WhiteListCommandHandler : ICommandHandler<DeleteSupplementDisease_WhiteListCommand, DeleteSupplementDisease_WhiteListCommandResult>
{
    private readonly ISupplementDisease_WhiteListRepository _SupplementDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSupplementDisease_WhiteListCommandHandler(ISupplementDisease_WhiteListRepository SupplementDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _SupplementDisease_WhiteListRepository = SupplementDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<DeleteSupplementDisease_WhiteListCommandResult>> Handle(DeleteSupplementDisease_WhiteListCommand command)
    {
        var result = await _SupplementDisease_WhiteListRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteSupplementDisease_WhiteListCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _SupplementDisease_WhiteListRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteSupplementDisease_WhiteListCommandResult("error", "delete SupplementDisease_WhiteList has error and rollback is done");

        return new DeleteSupplementDisease_WhiteListCommandResult("success", "ok");
    }
}
