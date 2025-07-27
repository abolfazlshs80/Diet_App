
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.user.Repository;

namespace Diet.Application.UseCase.Drug.Commands.Delete;

public class DeleteDrugCommandHandler : ICommandHandler<DeleteDrugCommand, DeleteDrugCommandResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDrugCommandHandler(IDrugRepository DrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DrugRepository = DrugRepository;
    }


    public async Task<ErrorOr<DeleteDrugCommandResult>> Handle(DeleteDrugCommand command)
    {
        var result = await _DrugRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteDrugCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
            await _DrugRepository.DeleteAsync(result);
            //TODO check rel
            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteDrugCommandResult("error", "update Drug  has error and rollback is done");
  
 

        return new DeleteDrugCommandResult("success", "ok");
    }
}
