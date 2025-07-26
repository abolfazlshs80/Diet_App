
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.LifeCourse.Commands.Create;

public class CreateLifeCourseCommandHandler : ICommandHandler<CreateLifeCourseCommand, CreateLifeCourseCommandResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLifeCourseCommandHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _LifeCourseRepository = LifeCourseRepository;
    }
 

    public async Task<ErrorOr<CreateLifeCourseCommandResult>> Handle(CreateLifeCourseCommand command)
    {

        var orderResult = Domain.lifeCourse.Entities.LifeCourse.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _LifeCourseRepository.AddAsync(orderResult.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateLifeCourseCommandResult("error", "Add LifeCourse has error and rollback is done");
        

        return new CreateLifeCourseCommandResult("success","ok");
    }
}
