using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.FoodDrugIntraction.Commands.Create;

public class CreateFoodDrugIntractionCommandHandler : ICommandHandler<CreateFoodDrugIntractionCommand, CreateFoodDrugIntractionCommandResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }
 

    public async Task<ErrorOr<CreateFoodDrugIntractionCommandResult>> Handle(CreateFoodDrugIntractionCommand command)
    {

        
        var orderResult = Domain.food.Entities.Food_Drug_Intraction.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodDrugIntractionRepository.AddAsync(orderResult.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateFoodDrugIntractionCommandResult("error", "Add Food Group has error and rollback is done");
        }


        return new CreateFoodDrugIntractionCommandResult("success","ok");
    }
}
