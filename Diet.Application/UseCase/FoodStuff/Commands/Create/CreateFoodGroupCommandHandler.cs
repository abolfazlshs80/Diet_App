using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.FoodStuff.Commands.Create;

public class CreateFoodStuffCommandHandler : ICommandHandler<CreateFoodStuffCommand, CreateFoodStuffCommandResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateFoodStuffCommandHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodStuffRepository = FoodStuffRepository;
    }
 

    public async Task<ErrorOr<CreateFoodStuffCommandResult>> Handle(CreateFoodStuffCommand command)
    {

        var orderResult = Domain.food.Entities.FoodStuff.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _FoodStuffRepository.AddAsync(orderResult.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateFoodStuffCommandResult("error", "Add Food Group has error and rollback is done");
        }


        return new CreateFoodStuffCommandResult("success","ok");
    }
}
