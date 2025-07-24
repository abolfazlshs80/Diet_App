using Diet.Application.Execptions;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Food.Domain.Food.Errors.DomainErrors;

namespace Diet.Application.UseCase.Food.Commands.Delete;

public class DeleteFoodCommandHandler : ICommandHandler<DeleteFoodCommand, DeleteFoodCommandResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public DeleteFoodCommandHandler(IFoodRepository foodRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodRepository = foodRepository;
    }


    public async Task<ErrorOr<DeleteFoodCommandResult>> Handle(DeleteFoodCommand command)
    {
        var result = await _foodRepository.ByIdAsync(command.Id);
        if (result == null)
            return Food_Error.Food_NotFount;
        try
        {
            await _unitOfWorkService.BeginTransactionAsync();
            await _foodRepository.DeleteAsync(result);
           //TODO check rel
            await _unitOfWorkService.CommitAsync();

        }
        catch (Exception)
        {

            await _unitOfWorkService.RollbackAsync();

            return new DeleteFoodCommandResult("error", "Add Food  has error and rollback is done");
        }
 

        return new DeleteFoodCommandResult("success", "ok");
    }
}
