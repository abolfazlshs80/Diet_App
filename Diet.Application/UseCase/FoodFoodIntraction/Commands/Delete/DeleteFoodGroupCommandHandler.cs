
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using static FoodFoodIntraction.Domain.FoodFoodIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodFoodIntraction.Commands.Delete;

public class DeleteFoodFoodIntractionCommandHandler : ICommandHandler<DeleteFoodFoodIntractionCommand, DeleteFoodFoodIntractionCommandResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFoodFoodIntractionCommandHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }


    public async Task<ErrorOr<DeleteFoodFoodIntractionCommandResult>> Handle(DeleteFoodFoodIntractionCommand command)
    {
        var result = await _FoodFoodIntractionRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteFoodFoodIntractionCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
             _FoodFoodIntractionRepository.Delete(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteFoodFoodIntractionCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteFoodFoodIntractionCommandResult("success", "ok");
    }
}
