
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Application.Interface;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.LifeCourse.Commands.Delete;

public class DeleteLifeCourseCommandHandler : ICommandHandler<DeleteLifeCourseCommand, DeleteLifeCourseCommandResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLifeCourseCommandHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _LifeCourseRepository = LifeCourseRepository;
    }


    public async Task<ErrorOr<DeleteLifeCourseCommandResult>> Handle(DeleteLifeCourseCommand command)
    {
        var result = await _LifeCourseRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteLifeCourseCommandResult("error", "NotFound LifeCourse");
    
            await _unitOfWork.BeginTransactionAsync();
             _LifeCourseRepository.Delete(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteLifeCourseCommandResult("error", "Add  LifeCourse has error and rollback is done");
     

        return new DeleteLifeCourseCommandResult("success", "ok");
    }
}
