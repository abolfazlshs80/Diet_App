using Diet.Domain.Contract.Commands.Transactions.Update;
using Diet.Application.Interface;
using Diet.Domain.transactions.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Transactions.Commands.Update;

public class UpdateTransactionsCommandHandler : ICommandHandler<UpdateTransactionsCommand, UpdateTransactionsCommandResult>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransactionsCommandHandler(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _transactionsRepository = transactionsRepository;
    }

    public async Task<ErrorOr<UpdateTransactionsCommandResult>> Handle(UpdateTransactionsCommand command)
    {
        var transactions = await _transactionsRepository.ByIdAsync(command.Id);
        if (transactions == null)
            return new UpdateTransactionsCommandResult("error", "not found transactions");

        var result = Domain.transactions.Transactions.Update(transactions, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _transactionsRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateTransactionsCommandResult("error", "Update Transactions has error and rollback is done");

        return new UpdateTransactionsCommandResult("success", "ok");
    }
}
