
using Diet.Domain.Contract;
using Diet.Application.Interface;
using Diet.Application.Interface;
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
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDurationAgeCommandHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DurationAgeRepository = DurationAgeRepository;
    }


    public async Task<ErrorOr<DeleteDurationAgeCommandResult>> Handle(DeleteDurationAgeCommand command)
    {
        var result = await _DurationAgeRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteDurationAgeCommandResult("error", "NotFound DurationAge");
 
            await _unitOfWork.BeginTransactionAsync();
            await _DurationAgeRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteDurationAgeCommandResult("error", "Add DurationAge has error and rollback is done");
       
 

        return new DeleteDurationAgeCommandResult("success", "ok");
    }
}
