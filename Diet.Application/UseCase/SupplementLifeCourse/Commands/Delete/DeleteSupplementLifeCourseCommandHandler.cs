using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementLifeCourse.Commands.Delete;

public class DeleteSupplementLifeCourseCommandHandler : ICommandHandler<DeleteSupplementLifeCourseCommand, DeleteSupplementLifeCourseCommandResult>
{
    private readonly ISupplementLifeCourseRepository _SupplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSupplementLifeCourseCommandHandler(ISupplementLifeCourseRepository SupplementLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _SupplementLifeCourseRepository = SupplementLifeCourseRepository;
    }

    public async Task<ErrorOr<DeleteSupplementLifeCourseCommandResult>> Handle(DeleteSupplementLifeCourseCommand command)
    {
        var result = await _SupplementLifeCourseRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteSupplementLifeCourseCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _SupplementLifeCourseRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteSupplementLifeCourseCommandResult("error", "delete SupplementLifeCourse has error and rollback is done");

        return new DeleteSupplementLifeCourseCommandResult("success", "ok");
    }
}
