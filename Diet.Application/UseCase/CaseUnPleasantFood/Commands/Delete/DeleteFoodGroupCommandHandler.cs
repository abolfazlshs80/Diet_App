
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using Diet.Domain.CaseUnPleasantFood.Repository;


namespace Diet.Application.UseCase.CaseUnPleasantFood.Commands.Delete;

public class DeleteCaseUnPleasantFoodCommandHandler : ICommandHandler<DeleteCaseUnPleasantFoodCommand, DeleteCaseUnPleasantFoodCommandResult>
{
    private readonly ICaseUnPleasantFoodRepository _CaseUnPleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCaseUnPleasantFoodCommandHandler(ICaseUnPleasantFoodRepository CaseUnPleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseUnPleasantFoodRepository = CaseUnPleasantFoodRepository;
    }


    public async Task<ErrorOr<DeleteCaseUnPleasantFoodCommandResult>> Handle(DeleteCaseUnPleasantFoodCommand command)
    {
        var result = await _CaseUnPleasantFoodRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCaseUnPleasantFoodCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
             _CaseUnPleasantFoodRepository.Delete(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteCaseUnPleasantFoodCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteCaseUnPleasantFoodCommandResult("success", "ok");
    }
}
