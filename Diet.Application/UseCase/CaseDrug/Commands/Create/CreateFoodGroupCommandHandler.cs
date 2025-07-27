
using Diet.Application.Interface;
using Diet.Domain.CaseDrug;
using Diet.Domain.CaseDrug.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.CaseDrug.Commands.Create;

public class CreateCaseDrugCommandHandler : ICommandHandler<CreateCaseDrugCommand, CreateCaseDrugCommandResult>
{
    private readonly ICaseDrugRepository _CaseDrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCaseDrugCommandHandler(ICaseDrugRepository CaseDrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDrugRepository = CaseDrugRepository;
    }
 

    public async Task<ErrorOr<CreateCaseDrugCommandResult>> Handle(CreateCaseDrugCommand command)
    {

        var Result =Domain.caseDrug. CaseDrug.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _CaseDrugRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateCaseDrugCommandResult("error", "Add Food_Food_Intraction Group has error and rollback is done");
        


        return new CreateCaseDrugCommandResult("success","ok");
    }
}
