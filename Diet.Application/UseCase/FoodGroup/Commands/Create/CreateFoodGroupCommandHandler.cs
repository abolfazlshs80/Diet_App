
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.FoodGroup.Commands.Create;

public class CreateFoodGroupCommandHandler : ICommandHandler<CreateFoodGroupCommand, CreateFoodGroupCommandResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFoodGroupCommandHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodGroupRepository = foodGroupRepository;
    }
 

    public async Task<ErrorOr<CreateFoodGroupCommandResult>> Handle(CreateFoodGroupCommand command)
    {

        var result = Domain.food.Entities.FoodGroup.Create(command);
        if (result.IsError)
            return result.FirstError;
     
            await _unitOfWork.BeginTransactionAsync();
            await _foodGroupRepository.AddAsync(result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateFoodGroupCommandResult("error", "Add Food Group has error and rollback is done");
      

        return new CreateFoodGroupCommandResult("success","ok");
    }
}
