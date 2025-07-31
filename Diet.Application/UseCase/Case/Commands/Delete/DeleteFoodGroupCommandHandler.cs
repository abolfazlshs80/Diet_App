
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;

using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Case.Commands.Delete;

public class DeleteCaseCommandHandler : ICommandHandler<DeleteCaseCommand, DeleteCaseCommandResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCaseCommandHandler(ICaseRepository CaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseRepository = CaseRepository;
    }


    public async Task<ErrorOr<DeleteCaseCommandResult>> Handle(DeleteCaseCommand command)
    {
        var result = await _CaseRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCaseCommandResult("errorFound", " not found Case ");

        await _unitOfWork.BeginTransactionAsync();
         _CaseRepository.Delete(result);
        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteCaseCommandResult("error", "Delete Case has error and rollback is done");
        return new DeleteCaseCommandResult("success", "ok");
    }
}
