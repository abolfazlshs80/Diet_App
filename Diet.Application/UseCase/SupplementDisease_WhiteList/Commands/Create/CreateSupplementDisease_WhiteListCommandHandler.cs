using Diet.Application.Interface;
using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Commands.Create;

public class CreateSupplementDisease_WhiteListCommandHandler : ICommandHandler<CreateSupplementDisease_WhiteListCommand, CreateSupplementDisease_WhiteListCommandResult>
{
    private readonly ISupplementDisease_WhiteListRepository _supplementDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementDisease_WhiteListCommandHandler(ISupplementDisease_WhiteListRepository supplementDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDisease_WhiteListRepository = supplementDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<CreateSupplementDisease_WhiteListCommandResult>> Handle(CreateSupplementDisease_WhiteListCommand command)
    {
        var result = Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementDisease_WhiteListRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSupplementDisease_WhiteListCommandResult("error", "Add SupplementDisease_WhiteList has error and rollback is done");

        return new CreateSupplementDisease_WhiteListCommandResult("success", "ok");
    }
}
