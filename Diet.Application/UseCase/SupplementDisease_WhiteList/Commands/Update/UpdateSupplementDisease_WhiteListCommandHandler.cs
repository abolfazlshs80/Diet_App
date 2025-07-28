using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;
using Diet.Application.Interface;
using Diet.Domain.supplementDisease_WhiteList.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Commands.Update;

public class UpdateSupplementDisease_WhiteListCommandHandler : ICommandHandler<UpdateSupplementDisease_WhiteListCommand, UpdateSupplementDisease_WhiteListCommandResult>
{
    private readonly ISupplementDisease_WhiteListRepository _supplementDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSupplementDisease_WhiteListCommandHandler(ISupplementDisease_WhiteListRepository supplementDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDisease_WhiteListRepository = supplementDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<UpdateSupplementDisease_WhiteListCommandResult>> Handle(UpdateSupplementDisease_WhiteListCommand command)
    {
        var supplementDisease_WhiteList = await _supplementDisease_WhiteListRepository.ByIdAsync(command.Id);
        if (supplementDisease_WhiteList == null)
            return new UpdateSupplementDisease_WhiteListCommandResult("error", "not found supplementdisease_whitelist");

        var result = Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList.Update(supplementDisease_WhiteList, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementDisease_WhiteListRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementDisease_WhiteListCommandResult("error", "Update SupplementDisease_WhiteList has error and rollback is done");

        return new UpdateSupplementDisease_WhiteListCommandResult("success", "ok");
    }
}
