
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using Diet.Domain.CaseSupplement.Repository;


namespace Diet.Application.UseCase.CaseSupplement.Commands.Delete;

public class DeleteCaseSupplementCommandHandler : ICommandHandler<DeleteCaseSupplementCommand, DeleteCaseSupplementCommandResult>
{
    private readonly ICaseSupplementRepository _CaseSupplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCaseSupplementCommandHandler(ICaseSupplementRepository CaseSupplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseSupplementRepository = CaseSupplementRepository;
    }


    public async Task<ErrorOr<DeleteCaseSupplementCommandResult>> Handle(DeleteCaseSupplementCommand command)
    {
        var result = await _CaseSupplementRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCaseSupplementCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
             _CaseSupplementRepository.Delete(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteCaseSupplementCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteCaseSupplementCommandResult("success", "ok");
    }
}
