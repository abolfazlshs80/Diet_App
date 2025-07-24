using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodDrugIntraction.Domain.FoodDrugIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodDrugIntraction.Commands.Update;

public class UpdateFoodDrugIntractionCommandHandler : ICommandHandler<UpdateFoodDrugIntractionCommand, UpdateFoodDrugIntractionCommandResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodDrugIntractionCommandResult>> Handle(UpdateFoodDrugIntractionCommand command)
    {

        var FoodDrugIntraction = await _FoodDrugIntractionRepository.ByIdAsync(command.Id);
        if (FoodDrugIntraction == null)
            return FoodDrugIntraction_Error.FoodDrugIntraction_NotFount;

        var result = Domain.food.Entities.Food_Drug_Intraction.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodDrugIntractionRepository.UpdateAsync(result.Value);
       
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateFoodDrugIntractionCommandResult("error", "Add Food Group has error and rollback is done");
        }
     

        return new UpdateFoodDrugIntractionCommandResult("success","ok");
    }
}
