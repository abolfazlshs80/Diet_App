using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Commands.Update;

public class UpdateFoodStuffCommandHandler : ICommandHandler<UpdateFoodStuffCommand, UpdateFoodStuffCommandResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateFoodStuffCommandHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodStuffRepository = FoodStuffRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodStuffCommandResult>> Handle(UpdateFoodStuffCommand command)
    {

        var FoodStuff = await _FoodStuffRepository.ByIdAsync(command.Id);
        if (FoodStuff == null)
            return FoodStuff_Error.FoodStuff_NotFount;

        var result = Domain.food.Entities.FoodStuff.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodStuffRepository.UpdateAsync(result.Value);
      
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateFoodStuffCommandResult("error", "Add Food Group has error and rollback is done");
        }
     

        return new UpdateFoodStuffCommandResult("success","ok");
    }
}
