using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.Drug.Commands.Create;

public class CreateDrugCommandHandler : ICommandHandler<CreateDrugCommand, CreateDrugCommandResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateDrugCommandHandler(IDrugRepository DrugRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DrugRepository = DrugRepository;
    }
 

    public async Task<ErrorOr<CreateDrugCommandResult>> Handle(CreateDrugCommand command)
    {

        var orderResult = Domain.drug.Entities.Drug.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _DrugRepository.AddAsync(orderResult.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateDrugCommandResult("error", "Add Drug  has error and rollback is done");
        }


        return new CreateDrugCommandResult("success","ok");
    }
}
