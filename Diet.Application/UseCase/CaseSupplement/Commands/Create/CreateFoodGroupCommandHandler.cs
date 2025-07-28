
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.CaseSupplement;
using Diet.Domain.CaseSupplement.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.supplement.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.CaseSupplement.Commands.Create;

public class CreateCaseSupplementCommandHandler : ICommandHandler<CreateCaseSupplementCommand, CreateCaseSupplementCommandResult>
{
    private readonly ICaseSupplementRepository _CaseSupplementRepository;
    private readonly ISupplementRepository _SupplementRepository;
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCaseSupplementCommandHandler(ICaseSupplementRepository CaseSupplementRepository
        , ICaseRepository CaseRepository
        , ISupplementRepository SupplementRepository
        , IUnitOfWork unitOfWork)
    {
        _CaseRepository = CaseRepository;
        _SupplementRepository = SupplementRepository;
        _unitOfWork = unitOfWork;
        _CaseSupplementRepository = CaseSupplementRepository;
    }
 

    public async Task<ErrorOr<CreateCaseSupplementCommandResult>> Handle(CreateCaseSupplementCommand command)
    {

        if (!await _CaseRepository.IsExists(command.CaseId))
            return new CreateCaseSupplementCommandResult("error", "Case is not Exists");
        if (!await _SupplementRepository.IsExists(command.SupplementId))
            return new CreateCaseSupplementCommandResult("error", "Supplement is not Exists");

        var Result =Domain.caseSupplement. CaseSupplement.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _CaseSupplementRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateCaseSupplementCommandResult("error", "Add Food_Food_Intraction Group has error and rollback is done");
        


        return new CreateCaseSupplementCommandResult("success","ok");
    }
}
