using Diet.Application.Execptions;
using Diet.Domain.Contract;
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
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateFoodGroupCommandHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodGroupRepository = foodGroupRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodGroupCommandResult>> Handle(UpdateFoodGroupCommand command)
    {

        var foodGroup = await _foodGroupRepository.ById(command.Id);
        if (foodGroup == null)
            return FoodGroup_Error.FoodGroup_NotFount;

        var result = Domain.food.Entities.FoodGroup.Update(command);
        if (result.IsError)
            return result.FirstError;

        await _foodGroupRepository.Update(result.Value);
        await _unitOfWorkService.SaveAsync();

        return new UpdateFoodGroupCommandResult("success","ok");
    }
}
