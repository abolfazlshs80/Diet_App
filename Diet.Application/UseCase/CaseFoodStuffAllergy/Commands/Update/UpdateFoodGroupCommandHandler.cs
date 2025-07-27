using Diet.Application.Interface;
using Diet.Domain.CaseFoodStuffAllergy.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Commands.Update;

public class UpdateCaseFoodStuffAllergyCommandHandler : ICommandHandler<UpdateCaseFoodStuffAllergyCommand, UpdateCaseFoodStuffAllergyCommandResult>
{
    private readonly ICaseFoodStuffAllergyRepository _CaseFoodStuffAllergyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCaseFoodStuffAllergyCommandHandler(ICaseFoodStuffAllergyRepository CaseFoodStuffAllergyRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseFoodStuffAllergyRepository = CaseFoodStuffAllergyRepository;
    }
 

    public async Task<ErrorOr<UpdateCaseFoodStuffAllergyCommandResult>> Handle(UpdateCaseFoodStuffAllergyCommand command)
    {

        var CaseFoodStuffAllergy = await _CaseFoodStuffAllergyRepository.ByIdAsync(command.Id);
        if (CaseFoodStuffAllergy == null)
            return new UpdateCaseFoodStuffAllergyCommandResult("error", "NotFound Food_Food_Intraction ");

        var result = Domain.caseFoodStuffAllergy.CaseFoodStuffAllergy.Update(CaseFoodStuffAllergy, command);
        if (result.IsError)
            return result.FirstError;


            await _unitOfWork.BeginTransactionAsync();
            await _CaseFoodStuffAllergyRepository.UpdateAsync(result.Value);

            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new UpdateCaseFoodStuffAllergyCommandResult("error", "Update Food_Food_Intraction has error and rollback is done");
      

        return new UpdateCaseFoodStuffAllergyCommandResult("success","ok");
    }
}
