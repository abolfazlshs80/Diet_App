using Diet.Application.Interface;
using Diet.Domain.CaseSupplement.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Diet.Application.UseCase.CaseSupplement.Commands.Update;

public class UpdateCaseSupplementCommandHandler : ICommandHandler<UpdateCaseSupplementCommand, UpdateCaseSupplementCommandResult>
{
    private readonly ICaseSupplementRepository _CaseSupplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseSupplementCommandHandler(ICaseSupplementRepository CaseSupplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseSupplementRepository = CaseSupplementRepository;
    }
 

    public async Task<ErrorOr<UpdateCaseSupplementCommandResult>> Handle(UpdateCaseSupplementCommand command)
    {

        var CaseSupplement = await _CaseSupplementRepository.ByIdAsync(command.Id);
        if (CaseSupplement == null)
            return new UpdateCaseSupplementCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.caseSupplement.CaseSupplement.Update(CaseSupplement, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _CaseSupplementRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateCaseSupplementCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateCaseSupplementCommandResult("success","ok");
    }
}
