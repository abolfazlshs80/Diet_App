
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Food.Domain.Food.Errors.DomainErrors;

namespace Diet.Application.UseCase.Food.Commands.Delete;

public class DeleteFoodCommandHandler : ICommandHandler<DeleteFoodCommand, DeleteFoodCommandResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodRepository = foodRepository;
    }


    public async Task<ErrorOr<DeleteFoodCommandResult>> Handle(DeleteFoodCommand command)
    {
        var result = await _foodRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteFoodCommandResult("error", "NotFound Food  ");

        await _unitOfWork.BeginTransactionAsync();
             _foodRepository.Delete(result);
           //TODO check rel
            await _unitOfWork.CommitAsync();
            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteFoodCommandResult("error", "Add Food  has error and rollback is done");
        
 

        return new DeleteFoodCommandResult("success", "ok");
    }
}
