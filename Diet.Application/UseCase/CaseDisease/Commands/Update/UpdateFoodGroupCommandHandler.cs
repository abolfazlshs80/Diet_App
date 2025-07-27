using Diet.Application.Interface;
using Diet.Domain.CaseDisease.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Diet.Application.UseCase.CaseDisease.Commands.Update;

public class UpdateCaseDiseaseCommandHandler : ICommandHandler<UpdateCaseDiseaseCommand, UpdateCaseDiseaseCommandResult>
{
    private readonly ICaseDiseaseRepository _CaseDiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseDiseaseCommandHandler(ICaseDiseaseRepository CaseDiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDiseaseRepository = CaseDiseaseRepository;
    }
 

    public async Task<ErrorOr<UpdateCaseDiseaseCommandResult>> Handle(UpdateCaseDiseaseCommand command)
    {

        var CaseDisease = await _CaseDiseaseRepository.ByIdAsync(command.Id);
        if (CaseDisease == null)
            return new UpdateCaseDiseaseCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.caseDisease.CaseDisease.Update(CaseDisease, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _CaseDiseaseRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateCaseDiseaseCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateCaseDiseaseCommandResult("success","ok");
    }
}
