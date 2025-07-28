using Diet.Application.Interface;
using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementLifeCourse.Commands.Create;

public class CreateSupplementLifeCourseCommandHandler : ICommandHandler<CreateSupplementLifeCourseCommand, CreateSupplementLifeCourseCommandResult>
{
    private readonly ISupplementLifeCourseRepository _supplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementLifeCourseCommandHandler(ISupplementLifeCourseRepository supplementLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementLifeCourseRepository = supplementLifeCourseRepository;
    }

    public async Task<ErrorOr<CreateSupplementLifeCourseCommandResult>> Handle(CreateSupplementLifeCourseCommand command)
    {
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
