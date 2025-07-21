using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.FoodGroup.Commands.Create;

public class CreateFoodGroupCommandHandler : ICommandHandler<CreateFoodGroupCommand, CreateFoodGroupCommandResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateFoodGroupCommandHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodGroupRepository = foodGroupRepository;
    }
 

    public async Task<ErrorOr<CreateFoodGroupCommandResult>> Handle(CreateFoodGroupCommand command)
    {

        var orderResult = Domain.food.Entities.FoodGroup.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;

        await _foodGroupRepository.Save(orderResult.Value!);
        await _unitOfWorkService.SaveAsync();

        return new CreateFoodGroupCommandResult("success","ok");
    }
}
