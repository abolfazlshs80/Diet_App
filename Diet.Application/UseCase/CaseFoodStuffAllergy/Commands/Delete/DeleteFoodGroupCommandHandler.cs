
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using Diet.Domain.CaseFoodStuffAllergy.Repository;


namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Commands.Delete;

public class DeleteCaseFoodStuffAllergyCommandHandler : ICommandHandler<DeleteCaseFoodStuffAllergyCommand, DeleteCaseFoodStuffAllergyCommandResult>
{
    private readonly ICaseFoodStuffAllergyRepository _CaseFoodStuffAllergyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCaseFoodStuffAllergyCommandHandler(ICaseFoodStuffAllergyRepository CaseFoodStuffAllergyRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseFoodStuffAllergyRepository = CaseFoodStuffAllergyRepository;
    }


    public async Task<ErrorOr<DeleteCaseFoodStuffAllergyCommandResult>> Handle(DeleteCaseFoodStuffAllergyCommand command)
    {
        var result = await _CaseFoodStuffAllergyRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteCaseFoodStuffAllergyCommandResult("error", "Not Found Food_Food_Intraction");

        await _unitOfWork.BeginTransactionAsync();
            await _CaseFoodStuffAllergyRepository.DeleteAsync(result);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new DeleteCaseFoodStuffAllergyCommandResult("error", "Delete Food_Food_Intraction has error and rollback is done");
        

        return new DeleteCaseFoodStuffAllergyCommandResult("success", "ok");
    }
}
