
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.Food.Commands.Create;

public class CreateFoodCommandHandler : ICommandHandler<CreateFoodCommand, CreateFoodCommandResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IFoodGroupRepository _FoodGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFoodCommandHandler(IFoodRepository foodRepository, IFoodGroupRepository FoodGroupRepository, IUnitOfWork unitOfWork)
    {
        _FoodGroupRepository = FoodGroupRepository;
        _unitOfWork = unitOfWork;
        _foodRepository = foodRepository;
    }
 

    public async Task<ErrorOr<CreateFoodCommandResult>> Handle(CreateFoodCommand command)
    {
        if (!await _FoodGroupRepository.IsExists(command.FoodGroupId))
            return new CreateFoodCommandResult("error", "FoodGroup is not Exists");
    
        var result = Domain.food.Entities.Food.Create(command);
        if (result.IsError)
            return result.FirstError;
      
            await _unitOfWork.BeginTransactionAsync();
            await _foodRepository.AddAsync(result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateFoodCommandResult("error", "Add Food  has error and rollback is done");
     

        return new CreateFoodCommandResult("success","ok");
    }
}
