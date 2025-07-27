
using Diet.Application.Interface;
using Diet.Domain.CaseDisease.Repository;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.CaseDisease.Commands.Create;

public class CreateCaseDiseaseCommandHandler : ICommandHandler<CreateCaseDiseaseCommand, CreateCaseDiseaseCommandResult>
{
    private readonly ICaseDiseaseRepository _CaseDiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCaseDiseaseCommandHandler(ICaseDiseaseRepository CaseDiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDiseaseRepository = CaseDiseaseRepository;
    }
 

    public async Task<ErrorOr<CreateCaseDiseaseCommandResult>> Handle(CreateCaseDiseaseCommand command)
    {

        var Result =Domain.caseDisease. CaseDisease.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _CaseDiseaseRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateCaseDiseaseCommandResult("error", "Add  CaseDisease has error and rollback is done");
        


        return new CreateCaseDiseaseCommandResult("success","ok");
    }
}
