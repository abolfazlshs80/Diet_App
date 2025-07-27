using Diet.Application.Interface;
using Diet.Domain.CaseUnPleasantFood.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Diet.Application.UseCase.CaseUnPleasantFood.Commands.Update;

public class UpdateCaseUnPleasantFoodCommandHandler : ICommandHandler<UpdateCaseUnPleasantFoodCommand, UpdateCaseUnPleasantFoodCommandResult>
{
    private readonly ICaseUnPleasantFoodRepository _CaseUnPleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseUnPleasantFoodCommandHandler(ICaseUnPleasantFoodRepository CaseUnPleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseUnPleasantFoodRepository = CaseUnPleasantFoodRepository;
    }
 

    public async Task<ErrorOr<UpdateCaseUnPleasantFoodCommandResult>> Handle(UpdateCaseUnPleasantFoodCommand command)
    {

        var CaseUnPleasantFood = await _CaseUnPleasantFoodRepository.ByIdAsync(command.Id);
        if (CaseUnPleasantFood == null)
            return new UpdateCaseUnPleasantFoodCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.caseUnPleasantFood.CaseUnPleasantFood.Update(CaseUnPleasantFood, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _CaseUnPleasantFoodRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateCaseUnPleasantFoodCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateCaseUnPleasantFoodCommandResult("success","ok");
    }
}
