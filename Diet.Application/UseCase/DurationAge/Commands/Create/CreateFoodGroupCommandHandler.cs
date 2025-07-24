using Diet.Application.Execptions;
using Diet.Domain.Contract;
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
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateDurationAgeCommandHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DurationAgeRepository = DurationAgeRepository;
    }
 

    public async Task<ErrorOr<CreateDurationAgeCommandResult>> Handle(CreateDurationAgeCommand command)
    {

        var orderResult = Domain.durationAge.Entities.DurationAge.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _DurationAgeRepository.AddAsync(orderResult.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateDurationAgeCommandResult("error", "Add DurationAge has error and rollback is done");
        }


        return new CreateDurationAgeCommandResult("success","ok");
    }
}
