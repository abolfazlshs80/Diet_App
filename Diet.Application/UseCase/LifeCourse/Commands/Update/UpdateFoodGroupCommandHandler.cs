using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.LifeCourse.Commands.Update;

public class UpdateLifeCourseCommandHandler : ICommandHandler<UpdateLifeCourseCommand, UpdateLifeCourseCommandResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public UpdateLifeCourseCommandHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _LifeCourseRepository = LifeCourseRepository;
    }
 

    public async Task<ErrorOr<UpdateLifeCourseCommandResult>> Handle(UpdateLifeCourseCommand command)
    {

        var LifeCourse = await _LifeCourseRepository.ByIdAsync(command.Id);
        if (LifeCourse == null)
            return LifeCourse_Error.LifeCourse_NotFount;

        var result = Domain.lifeCourse.Entities.LifeCourse.Update(command);
        if (result.IsError)
            return result.FirstError;


        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _LifeCourseRepository.UpdateAsync(result.Value);
      
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new UpdateLifeCourseCommandResult("error", "Add Food Group has error and rollback is done");
        }
     

        return new UpdateLifeCourseCommandResult("success","ok");
    }
}
