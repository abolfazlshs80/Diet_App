
using Diet.Domain.Contract;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Commands.Update;

public class UpdateFoodGroupCommandHandler : ICommandHandler<UpdateFoodGroupCommand, UpdateFoodGroupCommandResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFoodGroupCommandHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodGroupRepository = foodGroupRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodGroupCommandResult>> Handle(UpdateFoodGroupCommand command)
    {

        var foodGroup = await _foodGroupRepository.ByIdAsync(command.Id);
        if (foodGroup == null)
            return new UpdateFoodGroupCommandResult("error", "NotFound Food Group ");

        var result = Domain.food.Entities.FoodGroup.Update(foodGroup,command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _foodGroupRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateFoodGroupCommandResult("error", "Update Food Group has error and rollback is done");
       
     

        return new UpdateFoodGroupCommandResult("success","ok");
    }
}
