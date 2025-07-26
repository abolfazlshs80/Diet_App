using Diet.Application.Interface;
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
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDurationAgeCommandHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DurationAgeRepository = DurationAgeRepository;
    }
 

    public async Task<ErrorOr<UpdateDurationAgeCommandResult>> Handle(UpdateDurationAgeCommand command)
    {

        var DurationAge = await _DurationAgeRepository.ByIdAsync(command.Id);
        if (DurationAge == null)
            return new UpdateDurationAgeCommandResult("error", "NotFound DurationAge");

        var result = Domain.durationAge.Entities.DurationAge.Update(DurationAge, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _DurationAgeRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateDurationAgeCommandResult("error", "Add DurationAge has error and rollback is done");
      

        return new UpdateDurationAgeCommandResult("success","ok");
    }
}
