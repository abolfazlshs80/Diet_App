using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.Drug.Commands.Create;

public class CreateDrugCommandHandler : ICommandHandler<CreateDrugCommand, CreateDrugCommandResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDrugCommandHandler(IDrugRepository DrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DrugRepository = DrugRepository;
    }
 

    public async Task<ErrorOr<CreateDrugCommandResult>> Handle(CreateDrugCommand command)
    {

        var result = Domain.drug.Drug.Create(command);
        if (result.IsError)
            return result.FirstError;
    
            await _unitOfWork.BeginTransactionAsync();
            await _DrugRepository.AddAsync(result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateDrugCommandResult("error", "Add Drug  has error and rollback is done");
        


        return new CreateDrugCommandResult("success","ok");
    }
}
