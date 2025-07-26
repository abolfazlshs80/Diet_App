
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Application.Interface;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.FoodStuff.Commands.Create;

public class CreateFoodStuffCommandHandler : ICommandHandler<CreateFoodStuffCommand, CreateFoodStuffCommandResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFoodStuffCommandHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodStuffRepository = FoodStuffRepository;
    }
 

    public async Task<ErrorOr<CreateFoodStuffCommandResult>> Handle(CreateFoodStuffCommand command)
    {

        var result = Domain.food.Entities.FoodStuff.Create(command);
        if (result.IsError)
            return result.FirstError;
     
            await _unitOfWork.BeginTransactionAsync();
            await _FoodStuffRepository.AddAsync(result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateFoodStuffCommandResult("error", "Add FoodStuff has error and rollback is done");
      

        return new CreateFoodStuffCommandResult("success","ok");
    }
}
