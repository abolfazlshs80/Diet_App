
using Diet.Domain.Contract;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.DurationAge.Commands.Create;

public class CreateDurationAgeCommandHandler : ICommandHandler<CreateDurationAgeCommand, CreateDurationAgeCommandResult>
{
    private readonly IDurationAgeRepository _DurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDurationAgeCommandHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DurationAgeRepository = DurationAgeRepository;
    }
 

    public async Task<ErrorOr<CreateDurationAgeCommandResult>> Handle(CreateDurationAgeCommand command)
    {

        var result = Domain.durationAge.Entities.DurationAge.Create(command);
        if (result.IsError)
            return result.FirstError;
      
            await _unitOfWork.BeginTransactionAsync();
            await _DurationAgeRepository.AddAsync(result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateDurationAgeCommandResult("error", "Add DurationAge has error and rollback is done");
     

        return new CreateDurationAgeCommandResult("success","ok");
    }
}
