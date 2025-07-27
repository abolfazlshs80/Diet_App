
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using Diet.Domain.CasePleasantFood.Repository;


namespace Diet.Application.UseCase.CasePleasantFood.Commands.Delete;

public class DeleteCasePleasantFoodCommandHandler : ICommandHandler<DeleteCasePleasantFoodCommand, DeleteCasePleasantFoodCommandResult>
{
    private readonly ICasePleasantFoodRepository _CasePleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCasePleasantFoodCommandHandler(ICasePleasantFoodRepository CasePleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CasePleasantFoodRepository = CasePleasantFoodRepository;
    }


    public async Task<ErrorOr<DeleteCasePleasantFoodCommandResult>> Handle(DeleteCasePleasantFoodCommand command)
    {
        var result = await _CasePleasantFoodRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCasePleasantFoodCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
            await _CasePleasantFoodRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteCasePleasantFoodCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteCasePleasantFoodCommandResult("success", "ok");
    }
}
