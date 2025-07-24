using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;

using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Drug.Commands.Update;

public class UpdateDrugCommandHandler : ICommandHandler<UpdateDrugCommand, UpdateDrugCommandResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateDrugCommandHandler(IDrugRepository DrugRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DrugRepository = DrugRepository;
    }
 

    public async Task<ErrorOr<UpdateDrugCommandResult>> Handle(UpdateDrugCommand command)
    {

        var Drug = await _DrugRepository.ByIdAsync(command.Id);
        if (Drug == null)
            return Drug_Error.Drug_NotFount;

        var result = Domain.drug.Entities.Drug.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _DrugRepository.UpdateAsync(result.Value);
      
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateDrugCommandResult("error", "Add Drug  has error and rollback is done");
        }
     

        return new UpdateDrugCommandResult("success","ok");
    }
}
