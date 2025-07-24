using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodFoodIntraction.Domain.FoodFoodIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodFoodIntraction.Commands.Update;

public class UpdateFoodFoodIntractionCommandHandler : ICommandHandler<UpdateFoodFoodIntractionCommand, UpdateFoodFoodIntractionCommandResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateFoodFoodIntractionCommandHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodFoodIntractionCommandResult>> Handle(UpdateFoodFoodIntractionCommand command)
    {

        var FoodFoodIntraction = await _FoodFoodIntractionRepository.ByIdAsync(command.Id);
        if (FoodFoodIntraction == null)
            return FoodFoodIntraction_Error.FoodFoodIntraction_NotFount;

        var result = Domain.food.Entities.Food_Food_Intraction.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodFoodIntractionRepository.UpdateAsync(result.Value);
       
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateFoodFoodIntractionCommandResult("error", "Add Food Group has error and rollback is done");
        }
     

        return new UpdateFoodFoodIntractionCommandResult("success","ok");
    }
}
