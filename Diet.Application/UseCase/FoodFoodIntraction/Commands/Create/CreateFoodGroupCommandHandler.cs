
using Diet.Application.Interface;
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
    private readonly IUnitOfWork _unitOfWork;

    public CreateFoodFoodIntractionCommandHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }
 

    public async Task<ErrorOr<CreateFoodFoodIntractionCommandResult>> Handle(CreateFoodFoodIntractionCommand command)
    {

        var Result = Domain.food.Entities.Food_Food_Intraction.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _FoodFoodIntractionRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateFoodFoodIntractionCommandResult("error", "Add Food_Food_Intraction Group has error and rollback is done");
        


        return new CreateFoodFoodIntractionCommandResult("success","ok");
    }
}
