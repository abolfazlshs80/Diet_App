
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.disease.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Disease.Domain.Disease.Errors.DomainErrors;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Disease.Commands.Update;

public class UpdateDiseaseCommandHandler : ICommandHandler<UpdateDiseaseCommand, UpdateDiseaseCommandResult>
{
    private readonly IDiseaseRepository _DiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDiseaseCommandHandler(IDiseaseRepository DiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DiseaseRepository = DiseaseRepository;
    }


    public async Task<ErrorOr<UpdateDiseaseCommandResult>> Handle(UpdateDiseaseCommand command)
    {

        var Disease = await _DiseaseRepository.ByIdAsync(command.Id);
        if (Disease == null)
            return new UpdateDiseaseCommandResult("error", "not found");



        var result = Domain.disease.Disease.Update(Disease, command);
        if (result.IsError)
            return result.FirstError;



        await _unitOfWork.BeginTransactionAsync();
        await _DiseaseRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateDiseaseCommandResult("error", "Update Disease has error and rollback is done");




        return new UpdateDiseaseCommandResult("success", "ok");
    }
}
