using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementLifeCourse.Commands.Update;

public class UpdateSupplementLifeCourseCommandHandler : ICommandHandler<UpdateSupplementLifeCourseCommand, UpdateSupplementLifeCourseCommandResult>
{
    private readonly ISupplementLifeCourseRepository _supplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplementRepository _supplementRepository;
    private readonly ILifeCourseRepository _lifeCourseRepository;

    public UpdateSupplementLifeCourseCommandHandler(ISupplementLifeCourseRepository supplementLifeCourseRepository,

        ISupplementRepository supplementRepository,
        ILifeCourseRepository lifeCourseRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementLifeCourseRepository = supplementLifeCourseRepository;
        _lifeCourseRepository = lifeCourseRepository;
        _supplementRepository = supplementRepository;
    }


    public async Task<ErrorOr<UpdateSupplementLifeCourseCommandResult>> Handle(UpdateSupplementLifeCourseCommand command)
    {
        if (!await _supplementRepository.IsExists(command.SupplementId))
            return new UpdateSupplementLifeCourseCommandResult("error", "SupplementId is not Exists");
        if (!await _lifeCourseRepository.IsExists(command.LifeCourseId))
            return new UpdateSupplementLifeCourseCommandResult("error", "LifeCourseId is not Exists");

        var supplementLifeCourse = await _supplementLifeCourseRepository.ByIdAsync(command.Id);
        if (supplementLifeCourse == null)
            return new UpdateSupplementLifeCourseCommandResult("error", "not found supplementlifecourse");

        var result = Domain.supplementLifeCourse.SupplementLifeCourse.Update(supplementLifeCourse, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _supplementLifeCourseRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementLifeCourseCommandResult("error", "Update SupplementLifeCourse has error and rollback is done");

        return new UpdateSupplementLifeCourseCommandResult("success", "ok");
    }
}
