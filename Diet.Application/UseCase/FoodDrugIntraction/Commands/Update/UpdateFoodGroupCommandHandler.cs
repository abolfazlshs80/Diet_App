using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodDrugIntraction.Domain.FoodDrugIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodDrugIntraction.Commands.Update;

public class UpdateFoodDrugIntractionCommandHandler : ICommandHandler<UpdateFoodDrugIntractionCommand, UpdateFoodDrugIntractionCommandResult>
{
    private readonly IFoodRepository _FoodRepository;
    private readonly IDrugRepository _DrugRepository;
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository
        , IFoodRepository FoodRepository
        , IDrugRepository DrugRepository
        , IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
        _FoodRepository = FoodRepository;
        _DrugRepository = DrugRepository;
    }

    public async Task<ErrorOr<UpdateFoodDrugIntractionCommandResult>> Handle(UpdateFoodDrugIntractionCommand command)
    {
        if (!await _DrugRepository.IsExists(command.DrugId))
            return new UpdateFoodDrugIntractionCommandResult("error", "Drug is not Exists");
        if (!await _FoodRepository.IsExists(command.FoodId))
            return new UpdateFoodDrugIntractionCommandResult("error", "Food is not Exists");



        var FoodDrugIntraction = await _FoodDrugIntractionRepository.ByIdAsync(command.Id);
        if (FoodDrugIntraction == null)
            return new UpdateFoodDrugIntractionCommandResult("error", "NotFound FoodDrugIntraction  ");

        var result = Domain.food.Entities.Food_Drug_Intraction.Update(FoodDrugIntraction, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
             _FoodDrugIntractionRepository.Update(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateFoodDrugIntractionCommandResult("error", "Add Food FoodDrugIntraction has error and rollback is done");
       

        return new UpdateFoodDrugIntractionCommandResult("success","ok");
    }
}
