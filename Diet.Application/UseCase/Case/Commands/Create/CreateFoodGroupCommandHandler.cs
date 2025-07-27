
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;

using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;
using Diet.Domain.@case.Repository;

namespace Diet.Application.UseCase.Case.Commands.Create;

public class CreateCaseCommandHandler : ICommandHandler<CreateCaseCommand, CreateCaseCommandResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCaseCommandHandler(ICaseRepository CaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseRepository = CaseRepository;
    }


    public async Task<ErrorOr<CreateCaseCommandResult>> Handle(CreateCaseCommand command)
    {

        var CaseResult = Domain.Case.Case.Create(command);
        if (CaseResult.IsError)
            return CaseResult.FirstError;

        await _unitOfWork.BeginTransactionAsync();

        await _CaseRepository.AddAsync(CaseResult.Value);
        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value==Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateCaseCommandResult("error", "Add Case has error and rollback is done");
        return new CreateCaseCommandResult("success", "ok");
    }
}
