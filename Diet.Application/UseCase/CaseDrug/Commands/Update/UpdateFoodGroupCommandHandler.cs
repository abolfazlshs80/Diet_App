using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.CaseDrug.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Diet.Application.UseCase.CaseDrug.Commands.Update;

public class UpdateCaseDrugCommandHandler : ICommandHandler<UpdateCaseDrugCommand, UpdateCaseDrugCommandResult>
{
    private readonly ICaseDrugRepository _CaseDrugRepository;
    private readonly ICaseRepository _CaseRepository;
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseDrugCommandHandler(ICaseDrugRepository CaseDrugRepository,
        ICaseRepository CaseRepository,
        IDrugRepository DrugRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDrugRepository = CaseDrugRepository;
        _CaseRepository = CaseRepository;
        _DrugRepository = DrugRepository;
    }


    public async Task<ErrorOr<UpdateCaseDrugCommandResult>> Handle(UpdateCaseDrugCommand command)
    {
        if (!await _CaseRepository.IsExists(command.CaseId))
            return new UpdateCaseDrugCommandResult("error", "Case is not Exists");
        if (!await _DrugRepository.IsExists(command.CaseId))
            return new UpdateCaseDrugCommandResult("error", "Drug is not Exists");

        var CaseDrug = await _CaseDrugRepository.ByIdAsync(command.Id);
        if (CaseDrug == null)
            return new UpdateCaseDrugCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.caseDrug.CaseDrug.Update(CaseDrug, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _CaseDrugRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateCaseDrugCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateCaseDrugCommandResult("success","ok");
    }
}
