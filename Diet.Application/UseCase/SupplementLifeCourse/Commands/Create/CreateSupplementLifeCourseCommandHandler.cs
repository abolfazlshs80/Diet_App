using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementLifeCourse.Commands.Create;

public class CreateSupplementLifeCourseCommandHandler : ICommandHandler<CreateSupplementLifeCourseCommand, CreateSupplementLifeCourseCommandResult>
{
    private readonly ISupplementLifeCourseRepository _supplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplementRepository _supplementRepository;
    private readonly ILifeCourseRepository _lifeCourseRepository;

    public CreateSupplementLifeCourseCommandHandler(ISupplementLifeCourseRepository supplementLifeCourseRepository,

        ISupplementRepository supplementRepository,
        ILifeCourseRepository lifeCourseRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementLifeCourseRepository = supplementLifeCourseRepository;
        _lifeCourseRepository = lifeCourseRepository;
        _supplementRepository = supplementRepository;
    }

    public async Task<ErrorOr<CreateSupplementLifeCourseCommandResult>> Handle(CreateSupplementLifeCourseCommand command)
    {
        if (!await _supplementRepository.IsExists(command.SupplementId))
            return new CreateSupplementLifeCourseCommandResult("error", "SupplementId is not Exists");
        if (!await _lifeCourseRepository.IsExists(command.LifeCourseId))
            return new CreateSupplementLifeCourseCommandResult("error", "LifeCourseId is not Exists");

        var result = Domain.supplementLifeCourse.SupplementLifeCourse.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementLifeCourseRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSupplementLifeCourseCommandResult("error", "Add SupplementLifeCourse has error and rollback is done");

        return new CreateSupplementLifeCourseCommandResult("success", "ok");
    }
}
