
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Commands.Delete;

public class DeleteFoodStuffCommandHandler : ICommandHandler<DeleteFoodStuffCommand, DeleteFoodStuffCommandResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFoodStuffCommandHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodStuffRepository = FoodStuffRepository;
    }


    public async Task<ErrorOr<DeleteFoodStuffCommandResult>> Handle(DeleteFoodStuffCommand command)
    {
        var result = await _FoodStuffRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteFoodStuffCommandResult("error", "NotFound FoodStuff ");
       
            await _unitOfWork.BeginTransactionAsync();
            await _FoodStuffRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteFoodStuffCommandResult("error", "Delete FoodStuff has error and rollback is done");
      

        return new DeleteFoodStuffCommandResult("success", "ok");
    }
}
