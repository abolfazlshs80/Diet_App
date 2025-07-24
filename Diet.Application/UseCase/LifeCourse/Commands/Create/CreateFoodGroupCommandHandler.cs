using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.LifeCourse.Commands.Create;

public class CreateLifeCourseCommandHandler : ICommandHandler<CreateLifeCourseCommand, CreateLifeCourseCommandResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateLifeCourseCommandHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _LifeCourseRepository = LifeCourseRepository;
    }
 

    public async Task<ErrorOr<CreateLifeCourseCommandResult>> Handle(CreateLifeCourseCommand command)
    {

        var orderResult = Domain.lifeCourse.Entities.LifeCourse.Create(command);
        if (orderResult.IsError)
            return orderResult.FirstError;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _LifeCourseRepository.AddAsync(orderResult.Value);
 

            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new CreateLifeCourseCommandResult("error", "Add Food Group has error and rollback is done");
        }


        return new CreateLifeCourseCommandResult("success","ok");
    }
}
