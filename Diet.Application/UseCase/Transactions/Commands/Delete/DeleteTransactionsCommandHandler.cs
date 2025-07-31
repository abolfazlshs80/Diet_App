using Diet.Domain.transactions.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Transactions.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Transactions.Commands.Delete;

public class DeleteTransactionsCommandHandler : ICommandHandler<DeleteTransactionsCommand, DeleteTransactionsCommandResult>
{
    private readonly ITransactionsRepository _TransactionsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransactionsCommandHandler(ITransactionsRepository TransactionsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _TransactionsRepository = TransactionsRepository;
    }

    public async Task<ErrorOr<DeleteTransactionsCommandResult>> Handle(DeleteTransactionsCommand command)
    {
        var result = await _TransactionsRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteTransactionsCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _TransactionsRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteTransactionsCommandResult("error", "delete Transactions has error and rollback is done");

        return new DeleteTransactionsCommandResult("success", "ok");
    }
}
