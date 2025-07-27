
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using Diet.Domain.CaseDisease.Repository;


namespace Diet.Application.UseCase.CaseDisease.Commands.Delete;

public class DeleteCaseDiseaseCommandHandler : ICommandHandler<DeleteCaseDiseaseCommand, DeleteCaseDiseaseCommandResult>
{
    private readonly ICaseDiseaseRepository _CaseDiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCaseDiseaseCommandHandler(ICaseDiseaseRepository CaseDiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDiseaseRepository = CaseDiseaseRepository;
    }


    public async Task<ErrorOr<DeleteCaseDiseaseCommandResult>> Handle(DeleteCaseDiseaseCommand command)
    {
        var result = await _CaseDiseaseRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCaseDiseaseCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
            await _CaseDiseaseRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteCaseDiseaseCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteCaseDiseaseCommandResult("success", "ok");
    }
}
