
using Diet.Application.Interface;
using Diet.Domain.CasePleasantFood;
using Diet.Domain.CasePleasantFood.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.CasePleasantFood.Commands.Create;

public class CreateCasePleasantFoodCommandHandler : ICommandHandler<CreateCasePleasantFoodCommand, CreateCasePleasantFoodCommandResult>
{
    private readonly ICasePleasantFoodRepository _CasePleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCasePleasantFoodCommandHandler(ICasePleasantFoodRepository CasePleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CasePleasantFoodRepository = CasePleasantFoodRepository;
    }
 

    public async Task<ErrorOr<CreateCasePleasantFoodCommandResult>> Handle(CreateCasePleasantFoodCommand command)
    {

        var Result =Domain.casePleasantFood. CasePleasantFood.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _CasePleasantFoodRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateCasePleasantFoodCommandResult("error", "Add Food_Food_Intraction Group has error and rollback is done");
        


        return new CreateCasePleasantFoodCommandResult("success","ok");
    }
}
