using Diet.Application.Interface;
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
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseDrugCommandHandler(ICaseDrugRepository CaseDrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDrugRepository = CaseDrugRepository;
    }
 

    public async Task<ErrorOr<UpdateCaseDrugCommandResult>> Handle(UpdateCaseDrugCommand command)
    {

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
