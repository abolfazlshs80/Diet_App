using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
using Diet.Application.Interface;
using Diet.Domain.supplementLifeCourse.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementLifeCourse.Commands.Update;

public class UpdateSupplementLifeCourseCommandHandler : ICommandHandler<UpdateSupplementLifeCourseCommand, UpdateSupplementLifeCourseCommandResult>
{
    private readonly ISupplementLifeCourseRepository _supplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSupplementLifeCourseCommandHandler(ISupplementLifeCourseRepository supplementLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementLifeCourseRepository = supplementLifeCourseRepository;
    }

    public async Task<ErrorOr<UpdateSupplementLifeCourseCommandResult>> Handle(UpdateSupplementLifeCourseCommand command)
    {
        var supplementLifeCourse = await _supplementLifeCourseRepository.ByIdAsync(command.Id);
        if (supplementLifeCourse == null)
            return new UpdateSupplementLifeCourseCommandResult("error", "not found supplementlifecourse");

        var result = Domain.supplementLifeCourse.SupplementLifeCourse.Update(supplementLifeCourse, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementLifeCourseRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementLifeCourseCommandResult("error", "Update SupplementLifeCourse has error and rollback is done");

        return new UpdateSupplementLifeCourseCommandResult("success", "ok");
    }
}
