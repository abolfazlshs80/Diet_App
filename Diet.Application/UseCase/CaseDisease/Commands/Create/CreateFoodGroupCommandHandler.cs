
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.CaseDisease.Repository;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.disease.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.CaseDisease.Commands.Create;

public class CreateCaseDiseaseCommandHandler : ICommandHandler<CreateCaseDiseaseCommand, CreateCaseDiseaseCommandResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IDiseaseRepository _DiseaseRepository;
    private readonly ICaseDiseaseRepository _CaseDiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateCaseDiseaseCommandHandler(ICaseDiseaseRepository CaseDiseaseRepository,
        ICaseRepository CaseRepository,
        IDiseaseRepository DiseaseRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDiseaseRepository = CaseDiseaseRepository;
        _CaseRepository = CaseRepository;
        _DiseaseRepository = DiseaseRepository;
    }
 

    public async Task<ErrorOr<CreateCaseDiseaseCommandResult>> Handle(CreateCaseDiseaseCommand command)
    {
        if(!await _CaseRepository.IsExists(command.CaseId))
            return new CreateCaseDiseaseCommandResult("error", "Case is not Exists");
        if (!await _DiseaseRepository.IsExists(command.DiseaseId))
            return new CreateCaseDiseaseCommandResult("error", "Disease is not Exists");

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
