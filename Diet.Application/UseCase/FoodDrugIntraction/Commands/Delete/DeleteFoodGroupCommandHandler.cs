using Diet.Application.Interface;
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
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFoodDrugIntractionCommandHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }


    public async Task<ErrorOr<DeleteFoodDrugIntractionCommandResult>> Handle(DeleteFoodDrugIntractionCommand command)
    {
        var result = await _FoodDrugIntractionRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteFoodDrugIntractionCommandResult("error", "NotFound FoodDrugIntraction  ");

        await _unitOfWork.BeginTransactionAsync();
            await _FoodDrugIntractionRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteFoodDrugIntractionCommandResult("error", "Add FoodDrugIntraction  has error and rollback is done");
        

        return new DeleteFoodDrugIntractionCommandResult("success", "ok");
    }
}
