using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Drug.Commands.Delete;

public class DeleteDrugCommandHandler : ICommandHandler<DeleteDrugCommand, DeleteDrugCommandResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteDrugCommandHandler(IDrugRepository DrugRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DrugRepository = DrugRepository;
    }


    public async Task<ErrorOr<DeleteDrugCommandResult>> Handle(DeleteDrugCommand command)
    {
        var result = await _DrugRepository.ByIdAsync(command.Id);
        if (result == null)
            return Drug_Error.Drug_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _DrugRepository.DeleteAsync(result);
           //TODO check rel
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteDrugCommandResult("error", "Add Drug  has error and rollback is done");
        }
 

        return new DeleteDrugCommandResult("success", "ok");
    }
}
