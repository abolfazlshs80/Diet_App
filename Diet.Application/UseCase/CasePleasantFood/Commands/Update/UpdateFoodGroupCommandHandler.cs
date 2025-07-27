using Diet.Application.Interface;
using Diet.Domain.CasePleasantFood.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Diet.Application.UseCase.CasePleasantFood.Commands.Update;

public class UpdateCasePleasantFoodCommandHandler : ICommandHandler<UpdateCasePleasantFoodCommand, UpdateCasePleasantFoodCommandResult>
{
    private readonly ICasePleasantFoodRepository _CasePleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCasePleasantFoodCommandHandler(ICasePleasantFoodRepository CasePleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CasePleasantFoodRepository = CasePleasantFoodRepository;
    }
 

    public async Task<ErrorOr<UpdateCasePleasantFoodCommandResult>> Handle(UpdateCasePleasantFoodCommand command)
    {

        var CasePleasantFood = await _CasePleasantFoodRepository.ByIdAsync(command.Id);
        if (CasePleasantFood == null)
            return new UpdateCasePleasantFoodCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.casePleasantFood.CasePleasantFood.Update(CasePleasantFood, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _CasePleasantFoodRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateCasePleasantFoodCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateCasePleasantFoodCommandResult("success","ok");
    }
}
