
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.LifeCourse.Commands.Update;

public class UpdateLifeCourseCommandHandler : ICommandHandler<UpdateLifeCourseCommand, UpdateLifeCourseCommandResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLifeCourseCommandHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _LifeCourseRepository = LifeCourseRepository;
    }
 

    public async Task<ErrorOr<UpdateLifeCourseCommandResult>> Handle(UpdateLifeCourseCommand command)
    {
        if (command.ParentId != null && !await _LifeCourseRepository.IsExists(command.ParentId))
            return new UpdateLifeCourseCommandResult("error", "Not Found Disease");

        var LifeCourse = await _LifeCourseRepository.ByIdAsync(command.Id);
        if (LifeCourse == null)
            return new UpdateLifeCourseCommandResult("error", "NotFound LifeCourse");

        var result = Domain.lifeCourse.Entities.LifeCourse.Update(LifeCourse,command);
        if (result.IsError)
            return result.FirstError;


        
            await _unitOfWork.BeginTransactionAsync();
            await _LifeCourseRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateLifeCourseCommandResult("error", "Add LifeCourse has error and rollback is done");
       
        return new UpdateLifeCourseCommandResult("success","ok");
    }
}
