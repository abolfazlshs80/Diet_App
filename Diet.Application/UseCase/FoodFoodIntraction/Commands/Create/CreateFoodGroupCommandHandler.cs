using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.FoodFoodIntraction.Commands.Create;

public class CreateFoodFoodIntractionCommandHandler : ICommandHandler<CreateFoodFoodIntractionCommand, CreateFoodFoodIntractionCommandResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateFoodFoodIntractionCommandHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }
 

    public async Task<ErrorOr<CreateFoodFoodIntractionCommandResult>> Handle(CreateFoodFoodIntractionCommand command)
    {

        var Result = Domain.food.Entities.Food_Food_Intraction.Create(command);
        if (Result.IsError)
            return Result.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodFoodIntractionRepository.AddAsync(Result.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateFoodFoodIntractionCommandResult("error", "Add Food Group has error and rollback is done");
        }


        return new CreateFoodFoodIntractionCommandResult("success","ok");
    }
}
