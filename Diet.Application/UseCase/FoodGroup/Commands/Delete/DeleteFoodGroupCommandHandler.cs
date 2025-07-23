using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
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
        var result = await _foodGroupRepository.ByIdAsync(command.Id);
        if (result == null)
            return FoodGroup_Error.FoodGroup_NotFount;
        try
        {
            await _foodGroupRepository.DeleteAsync(result);
            await _unitOfWorkService.SaveAsync();
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteFoodGroupCommandResult("error", "Add Food Group has error and rollback is done");
        }
 

        return new DeleteFoodGroupCommandResult("success", "ok");
    }
}
