using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Commands.Delete;

public class DeleteFoodGroupCommandHandler : ICommandHandler<DeleteFoodGroupCommand, DeleteFoodGroupCommandResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFoodGroupCommandHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodGroupRepository = foodGroupRepository;
    }


    public async Task<ErrorOr<DeleteFoodGroupCommandResult>> Handle(DeleteFoodGroupCommand command)
    {
        var result = await _foodGroupRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteFoodGroupCommandResult("error", "NotFound Food Group ");
     
            await _unitOfWork.BeginTransactionAsync();
             _foodGroupRepository.Delete(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteFoodGroupCommandResult("error", "Delte Food Group has error and rollback is done");
        

        return new DeleteFoodGroupCommandResult("success", "ok");
    }
}
