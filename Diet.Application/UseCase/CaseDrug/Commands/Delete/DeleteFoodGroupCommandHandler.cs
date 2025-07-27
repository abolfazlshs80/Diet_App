
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using Diet.Domain.CaseDrug.Repository;


namespace Diet.Application.UseCase.CaseDrug.Commands.Delete;

public class DeleteCaseDrugCommandHandler : ICommandHandler<DeleteCaseDrugCommand, DeleteCaseDrugCommandResult>
{
    private readonly ICaseDrugRepository _CaseDrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCaseDrugCommandHandler(ICaseDrugRepository CaseDrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDrugRepository = CaseDrugRepository;
    }


    public async Task<ErrorOr<DeleteCaseDrugCommandResult>> Handle(DeleteCaseDrugCommand command)
    {
        var result = await _CaseDrugRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCaseDrugCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
            await _CaseDrugRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteCaseDrugCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteCaseDrugCommandResult("success", "ok");
    }
}
