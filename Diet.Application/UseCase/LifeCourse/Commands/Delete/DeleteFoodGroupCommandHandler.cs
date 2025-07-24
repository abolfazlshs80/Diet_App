using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.LifeCourse.Commands.Delete;

public class DeleteLifeCourseCommandHandler : ICommandHandler<DeleteLifeCourseCommand, DeleteLifeCourseCommandResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteLifeCourseCommandHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _LifeCourseRepository = LifeCourseRepository;
    }


    public async Task<ErrorOr<DeleteLifeCourseCommandResult>> Handle(DeleteLifeCourseCommand command)
    {
        var result = await _LifeCourseRepository.ByIdAsync(command.Id);
        if (result == null)
            return LifeCourse_Error.LifeCourse_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _LifeCourseRepository.DeleteAsync(result);
           
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteLifeCourseCommandResult("error", "Add Food Group has error and rollback is done");
        }
 

        return new DeleteLifeCourseCommandResult("success", "ok");
    }
}
