
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Commands.Update;

public class UpdateFoodStuffCommandHandler : ICommandHandler<UpdateFoodStuffCommand, UpdateFoodStuffCommandResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFoodStuffCommandHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodStuffRepository = FoodStuffRepository;
    }
 

    public async Task<ErrorOr<UpdateFoodStuffCommandResult>> Handle(UpdateFoodStuffCommand command)
    {

        var FoodStuff = await _FoodStuffRepository.ByIdAsync(command.Id);
        if (FoodStuff == null)
            return new UpdateFoodStuffCommandResult("error", "NotFound FoodStuff ");


        var result = Domain.food.Entities.FoodStuff.Update(FoodStuff, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
             _FoodStuffRepository.Update(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateFoodStuffCommandResult("error", "Update ete FoodStuff has error and rollback is done");
        

        return new UpdateFoodStuffCommandResult("success","ok");
    }
}
