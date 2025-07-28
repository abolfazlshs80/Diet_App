using Diet.Application.Interface;
using Diet.Domain.sport.Repository;
using Diet.Domain.Contract.Commands.Sport.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Sport.Commands.Create;

public class CreateSportCommandHandler : ICommandHandler<CreateSportCommand, CreateSportCommandResult>
{
    private readonly ISportRepository _sportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSportCommandHandler(ISportRepository sportRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _sportRepository = sportRepository;
    }

    public async Task<ErrorOr<CreateSportCommandResult>> Handle(CreateSportCommand command)
    {
        var result = Domain.sport.Sport.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _sportRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSportCommandResult("error", "Add Sport has error and rollback is done");

        return new CreateSportCommandResult("success", "ok");
    }
}
