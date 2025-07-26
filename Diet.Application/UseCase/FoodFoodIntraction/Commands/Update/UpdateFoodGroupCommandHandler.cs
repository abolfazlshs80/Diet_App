using Diet.Application.Interface;
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
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFoodFoodIntractionCommandHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodFoodIntractionCommandResult>> Handle(UpdateFoodFoodIntractionCommand command)
    {

        var FoodFoodIntraction = await _FoodFoodIntractionRepository.ByIdAsync(command.Id);
        if (FoodFoodIntraction == null)
            return new UpdateFoodFoodIntractionCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.food.Entities.Food_Food_Intraction.Update(FoodFoodIntraction,command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _FoodFoodIntractionRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateFoodFoodIntractionCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateFoodFoodIntractionCommandResult("success","ok");
    }
}
