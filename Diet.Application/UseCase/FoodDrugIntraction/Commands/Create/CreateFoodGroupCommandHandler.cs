
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;
using Diet.Application.Interface;

namespace Diet.Application.UseCase.FoodDrugIntraction.Commands.Create;

public class CreateFoodDrugIntractionCommandHandler : ICommandHandler<CreateFoodDrugIntractionCommand, CreateFoodDrugIntractionCommandResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }
 

    public async Task<ErrorOr<CreateFoodDrugIntractionCommandResult>> Handle(CreateFoodDrugIntractionCommand command)
    {

        
        var result = Domain.food.Entities.Food_Drug_Intraction.Create(command);
        if (result.IsError)
            return result.FirstError;
      
            await _unitOfWork.BeginTransactionAsync();
            await _FoodDrugIntractionRepository.AddAsync(result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateFoodDrugIntractionCommandResult("error", "Add Food_Drug_Intraction Group has error and rollback is done");
        

        return new CreateFoodDrugIntractionCommandResult("success","ok");
    }
}
