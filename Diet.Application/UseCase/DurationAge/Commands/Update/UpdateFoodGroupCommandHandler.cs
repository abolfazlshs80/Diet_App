using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.DurationAge.Commands.Update;

public class UpdateDurationAgeCommandHandler : ICommandHandler<UpdateDurationAgeCommand, UpdateDurationAgeCommandResult>
{
    private readonly IDurationAgeRepository _DurationAgeRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateDurationAgeCommandHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DurationAgeRepository = DurationAgeRepository;
    }
 

    public async Task<ErrorOr<UpdateDurationAgeCommandResult>> Handle(UpdateDurationAgeCommand command)
    {

        var DurationAge = await _DurationAgeRepository.ByIdAsync(command.Id);
        if (DurationAge == null)
            return DurationAge_Error.DurationAge_NotFount;

        var result = Domain.durationAge.Entities.DurationAge.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _DurationAgeRepository.UpdateAsync(result.Value);
      
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateDurationAgeCommandResult("error", "Add DurationAge has error and rollback is done");
        }
     

        return new UpdateDurationAgeCommandResult("success","ok");
    }
}
