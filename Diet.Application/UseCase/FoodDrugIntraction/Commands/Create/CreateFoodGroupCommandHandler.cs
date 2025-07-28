
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
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
    private readonly IFoodRepository _FoodRepository;
    private readonly IDrugRepository _DrugRepository;
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository
        , IFoodRepository FoodRepository
        , IDrugRepository DrugRepository
        , IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
        _FoodRepository = FoodRepository;
        _DrugRepository = DrugRepository;
    }
 

    public async Task<ErrorOr<CreateFoodDrugIntractionCommandResult>> Handle(CreateFoodDrugIntractionCommand command)
    {

        if (!await _DrugRepository.IsExists(command.DrugId))
            return new CreateFoodDrugIntractionCommandResult("error", "Drug is not Exists");
        if (!await _FoodRepository.IsExists(command.FoodId))
            return new CreateFoodDrugIntractionCommandResult("error", "Food is not Exists");


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
