
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Food.Domain.Food.Errors.DomainErrors;

namespace Diet.Application.UseCase.Food.Commands.Update;

public class UpdateFoodCommandHandler : ICommandHandler<UpdateFoodCommand, UpdateFoodCommandResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodRepository = foodRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodCommandResult>> Handle(UpdateFoodCommand command)
    {

        var food = await _foodRepository.ByIdAsync(command.Id);
        if (food == null)
            return new UpdateFoodCommandResult("error", "NotFound Food  ");

        var result = Domain.food.Entities.Food.Update(food,command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _foodRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateFoodCommandResult("error", "Add Food  has error and rollback is done");
        

        return new UpdateFoodCommandResult("success","ok");
    }
}
