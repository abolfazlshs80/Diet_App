using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodFoodIntraction.Domain.FoodFoodIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodFoodIntraction.Commands.Delete;

public class DeleteFoodFoodIntractionCommandHandler : ICommandHandler<DeleteFoodFoodIntractionCommand, DeleteFoodFoodIntractionCommandResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteFoodFoodIntractionCommandHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }


    public async Task<ErrorOr<DeleteFoodFoodIntractionCommandResult>> Handle(DeleteFoodFoodIntractionCommand command)
    {
        var result = await _FoodFoodIntractionRepository.ByIdAsync(command.Id);
        if (result == null)
            return FoodFoodIntraction_Error.FoodFoodIntraction_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodFoodIntractionRepository.DeleteAsync(result);
           
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteFoodFoodIntractionCommandResult("error", "Add Food Group has error and rollback is done");
        }
 

        return new DeleteFoodFoodIntractionCommandResult("success", "ok");
    }
}
