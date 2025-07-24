using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Commands.Delete;

public class DeleteFoodStuffCommandHandler : ICommandHandler<DeleteFoodStuffCommand, DeleteFoodStuffCommandResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteFoodStuffCommandHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodStuffRepository = FoodStuffRepository;
    }


    public async Task<ErrorOr<DeleteFoodStuffCommandResult>> Handle(DeleteFoodStuffCommand command)
    {
        var result = await _FoodStuffRepository.ByIdAsync(command.Id);
        if (result == null)
            return FoodStuff_Error.FoodStuff_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodStuffRepository.DeleteAsync(result);
           
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteFoodStuffCommandResult("error", "Add Food Group has error and rollback is done");
        }
 

        return new DeleteFoodStuffCommandResult("success", "ok");
    }
}
