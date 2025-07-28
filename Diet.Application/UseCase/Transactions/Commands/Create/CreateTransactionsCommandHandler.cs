using Diet.Application.Interface;
using Diet.Domain.transactions.Repository;
using Diet.Domain.Contract.Commands.Transactions.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Transactions.Commands.Create;

public class CreateTransactionsCommandHandler : ICommandHandler<CreateTransactionsCommand, CreateTransactionsCommandResult>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransactionsCommandHandler(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _transactionsRepository = transactionsRepository;
    }

    public async Task<ErrorOr<CreateTransactionsCommandResult>> Handle(CreateTransactionsCommand command)
    {
        var result = Domain.transactions.Transactions.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _transactionsRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateTransactionsCommandResult("error", "Add Transactions has error and rollback is done");

        return new CreateTransactionsCommandResult("success", "ok");
    }
}
