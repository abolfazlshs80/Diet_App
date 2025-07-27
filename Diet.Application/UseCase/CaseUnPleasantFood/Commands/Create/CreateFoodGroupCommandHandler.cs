
using Diet.Application.Interface;
using Diet.Domain.CaseUnPleasantFood;
using Diet.Domain.CaseUnPleasantFood.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.CaseUnPleasantFood.Commands.Create;

public class CreateCaseUnPleasantFoodCommandHandler : ICommandHandler<CreateCaseUnPleasantFoodCommand, CreateCaseUnPleasantFoodCommandResult>
{
    private readonly ICaseUnPleasantFoodRepository _CaseUnPleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCaseUnPleasantFoodCommandHandler(ICaseUnPleasantFoodRepository CaseUnPleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseUnPleasantFoodRepository = CaseUnPleasantFoodRepository;
    }
 

    public async Task<ErrorOr<CreateCaseUnPleasantFoodCommandResult>> Handle(CreateCaseUnPleasantFoodCommand command)
    {

        var Result =Domain.caseUnPleasantFood. CaseUnPleasantFood.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _CaseUnPleasantFoodRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateCaseUnPleasantFoodCommandResult("error", "Add Food_Food_Intraction Group has error and rollback is done");
        


        return new CreateCaseUnPleasantFoodCommandResult("success","ok");
    }
}
