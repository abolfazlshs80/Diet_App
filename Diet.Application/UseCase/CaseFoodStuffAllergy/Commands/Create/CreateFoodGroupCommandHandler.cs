
using Diet.Application.Interface;
using Diet.Domain.@case.Repository;
using Diet.Domain.CaseFoodStuffAllergy;
using Diet.Domain.CaseFoodStuffAllergy.Repository;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Commands.Create;

public class CreateCaseFoodStuffAllergyCommandHandler : ICommandHandler<CreateCaseFoodStuffAllergyCommand, CreateCaseFoodStuffAllergyCommandResult>
{
    private readonly ICaseFoodStuffAllergyRepository _CaseFoodStuffAllergyRepository;
    private readonly ICaseRepository _CaseRepository;
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCaseFoodStuffAllergyCommandHandler(ICaseFoodStuffAllergyRepository CaseFoodStuffAllergyRepository
        , ICaseRepository CaseRepository
        , IFoodStuffRepository FoodStuffRepository
        , IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseFoodStuffAllergyRepository = CaseFoodStuffAllergyRepository;
        _CaseRepository = CaseRepository;
        _FoodStuffRepository = FoodStuffRepository;
    }
 

    public async Task<ErrorOr<CreateCaseFoodStuffAllergyCommandResult>> Handle(CreateCaseFoodStuffAllergyCommand command)
    {

        if (!await _CaseRepository.IsExists(command.CaseId))
            return new CreateCaseFoodStuffAllergyCommandResult("error", "Case is not Exists");
        if (!await _FoodStuffRepository.IsExists(command.FoodStuffId))
            return new CreateCaseFoodStuffAllergyCommandResult("error", "FoodStuff is not Exists");

        var Result =Domain.caseFoodStuffAllergy. CaseFoodStuffAllergy.Create(command);
        if (Result.IsError)
            return Result.FirstError;
       
            await _unitOfWork.BeginTransactionAsync();
            await _CaseFoodStuffAllergyRepository.AddAsync(Result.Value);


            var commitState = await _unitOfWork.CommitAsync();

            if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
                return new CreateCaseFoodStuffAllergyCommandResult("error", "Add Food_Food_Intraction Group has error and rollback is done");
        


        return new CreateCaseFoodStuffAllergyCommandResult("success","ok");
    }
}
