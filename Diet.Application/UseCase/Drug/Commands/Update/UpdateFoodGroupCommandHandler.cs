using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Application.Interface;

using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.user.Repository;

namespace Diet.Application.UseCase.Drug.Commands.Update;

public class UpdateDrugCommandHandler : ICommandHandler<UpdateDrugCommand, UpdateDrugCommandResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDrugCommandHandler(IDrugRepository DrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DrugRepository = DrugRepository;
    }
 

    public async Task<ErrorOr<UpdateDrugCommandResult>> Handle(UpdateDrugCommand command)
    {

        var Drug = await _DrugRepository.ByIdAsync(command.Id);
        if (Drug == null)
            return new UpdateDrugCommandResult("error", "not found drug");

        var result = Domain.drug.Drug.Update(Drug, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _DrugRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateDrugCommandResult("error", "Add Drug  has error and rollback is done");
       

        return new UpdateDrugCommandResult("success","ok");
    }
}
