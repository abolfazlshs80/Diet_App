
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.role.Repository;
using Diet.Domain.sport.Repository;
using Diet.Domain.transactions.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.Case.Commands.Create;

public class CreateCaseCommandHandler : ICommandHandler<CreateCaseCommand, CreateCaseCommandResult>
{
    private readonly ICaseRepository _CaseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _usersRepository;
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly ISportRepository _sportRepository;
    private readonly ILifeCourseRepository _lifeCourseRepository;

    public CreateCaseCommandHandler(ICaseRepository CaseRepository,

        IUsersRepository usersRepository,
        ITransactionsRepository transactionsRepository,
        ISportRepository sportRepository,
        ILifeCourseRepository lifeCourseRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseRepository = CaseRepository;

        _usersRepository = usersRepository;
        _lifeCourseRepository = lifeCourseRepository;
        _sportRepository = sportRepository;
        _transactionsRepository = transactionsRepository;
    }


    public async Task<ErrorOr<CreateCaseCommandResult>> Handle(CreateCaseCommand command)
    {

        if (!await _usersRepository.IsExists(command.UserId))
            return new CreateCaseCommandResult("error", "UserId is not Exists");
        if (!await _lifeCourseRepository.IsExists(command.LifeCourseId))
            return new CreateCaseCommandResult("error", "LifeCourseId is not Exists");
        if (!await _sportRepository.IsExists(command.SportId))
            return new CreateCaseCommandResult("error", "SportId is not Exists");
        if (!await _transactionsRepository.IsExists(command.TransactionId))
            return new CreateCaseCommandResult("error", "TransactionId is not Exists");

        var CaseResult = Domain.Case.Case.Create(command);
        if (CaseResult.IsError)
            return CaseResult.FirstError;

        await _unitOfWork.BeginTransactionAsync();

        await _CaseRepository.AddAsync(CaseResult.Value);
        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value==Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateCaseCommandResult("error", "Add Case has error and rollback is done");
        return new CreateCaseCommandResult("success", "ok");
    }
}
