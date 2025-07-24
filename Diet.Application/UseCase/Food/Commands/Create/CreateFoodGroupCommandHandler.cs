using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.Food.Commands.Create;

public class CreateFoodCommandHandler : ICommandHandler<CreateFoodCommand, CreateFoodCommandResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodRepository = foodRepository;
    }
 

    public async Task<ErrorOr<CreateFoodCommandResult>> Handle(CreateFoodCommand command)
    {

        var orderResult = Domain.food.Entities.Food.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _foodRepository.AddAsync(orderResult.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateFoodCommandResult("error", "Add Food  has error and rollback is done");
        }


        return new CreateFoodCommandResult("success","ok");
    }
}
