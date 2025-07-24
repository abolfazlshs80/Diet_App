using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.DurationAge.Commands.Delete;

public class DeleteDurationAgeCommandHandler : ICommandHandler<DeleteDurationAgeCommand, DeleteDurationAgeCommandResult>
{
    private readonly IDurationAgeRepository _DurationAgeRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteDurationAgeCommandHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DurationAgeRepository = DurationAgeRepository;
    }


    public async Task<ErrorOr<DeleteDurationAgeCommandResult>> Handle(DeleteDurationAgeCommand command)
    {
        var result = await _DurationAgeRepository.ByIdAsync(command.Id);
        if (result == null)
            return DurationAge_Error.DurationAge_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _DurationAgeRepository.DeleteAsync(result);
           
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteDurationAgeCommandResult("error", "Add DurationAge has error and rollback is done");
        }
 

        return new DeleteDurationAgeCommandResult("success", "ok");
    }
}
