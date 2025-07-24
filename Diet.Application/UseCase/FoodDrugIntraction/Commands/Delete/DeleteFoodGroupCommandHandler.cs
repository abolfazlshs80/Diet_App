using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodDrugIntraction.Domain.FoodDrugIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodDrugIntraction.Commands.Delete;

public class DeleteFoodDrugIntractionCommandHandler : ICommandHandler<DeleteFoodDrugIntractionCommand, DeleteFoodDrugIntractionCommandResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }


    public async Task<ErrorOr<DeleteFoodDrugIntractionCommandResult>> Handle(DeleteFoodDrugIntractionCommand command)
    {
        var result = await _FoodDrugIntractionRepository.ByIdAsync(command.Id);
        if (result == null)
            return FoodDrugIntraction_Error.FoodDrugIntraction_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodDrugIntractionRepository.DeleteAsync(result);
           
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteFoodDrugIntractionCommandResult("error", "Add Food Group has error and rollback is done");
        }
 

        return new DeleteFoodDrugIntractionCommandResult("success", "ok");
    }
}
