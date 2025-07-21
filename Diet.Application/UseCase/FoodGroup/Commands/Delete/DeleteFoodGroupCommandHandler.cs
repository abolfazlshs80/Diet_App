using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Commands.Delete;

public class DeleteFoodGroupCommandHandler : ICommandHandler<DeleteFoodGroupCommand, DeleteFoodGroupCommandResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteFoodGroupCommandHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodGroupRepository = foodGroupRepository;
    }


    public async Task<ErrorOr<DeleteFoodGroupCommandResult>> Handle(DeleteFoodGroupCommand command)
    {
        var result = await _foodGroupRepository.ById(command.Id);
        if (result == null)
            return FoodGroup_Error.FoodGroup_NotFount;

        await _foodGroupRepository.Delete(result);
        await _unitOfWorkService.SaveAsync();

        return new DeleteFoodGroupCommandResult("success", "ok");
    }
}
