using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
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
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodRepository = foodRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodCommandResult>> Handle(UpdateFoodCommand command)
    {

        var food = await _foodRepository.ByIdAsync(command.Id);
        if (food == null)
            return Food_Error.Food_NotFount;

        var result = Domain.food.Entities.Food.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _foodRepository.UpdateAsync(result.Value);
      
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateFoodCommandResult("error", "Add Food  has error and rollback is done");
        }
     

        return new UpdateFoodCommandResult("success","ok");
    }
}
