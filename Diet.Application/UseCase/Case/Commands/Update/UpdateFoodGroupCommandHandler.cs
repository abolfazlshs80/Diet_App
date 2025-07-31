
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;

using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Case.Commands.Update;

public class UpdateCaseCommandHandler : ICommandHandler<UpdateCaseCommand, UpdateCaseCommandResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseCommandHandler(ICaseRepository CaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseRepository = CaseRepository;
    }


    public async Task<ErrorOr<UpdateCaseCommandResult>> Handle(UpdateCaseCommand command)
    {

        var Case = await _CaseRepository.ByIdAsync(command.Id);
        if (Case == null)
            return new UpdateCaseCommandResult("error", "not found");



        var result = Domain.Case.Case.Update(Case, command);
        if (result.IsError)
            return result.FirstError;



        await _unitOfWork.BeginTransactionAsync();
         _CaseRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateCaseCommandResult("error", "Update Case has error and rollback is done");




        return new UpdateCaseCommandResult("success", "ok");
    }
}
