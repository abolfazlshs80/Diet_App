
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Threading;

namespace Diet.Application.UseCase.Disease.Commands.Create;

public class CreateDiseaseCommandHandler : ICommandHandler<CreateDiseaseCommand, CreateDiseaseCommandResult>
{
    private readonly IDiseaseRepository _DiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDiseaseCommandHandler(IDiseaseRepository DiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DiseaseRepository = DiseaseRepository;
    }


    public async Task<ErrorOr<CreateDiseaseCommandResult>> Handle(CreateDiseaseCommand command)
    {
        if (command.ParentId != null && !await _DiseaseRepository.IsExists(command.ParentId))
            return new CreateDiseaseCommandResult("error", "Not Found Disease");

        var diseaseResult = Domain.disease.Disease.Create(command);
        if (diseaseResult.IsError)
            return diseaseResult.FirstError;

        await _unitOfWork.BeginTransactionAsync();

        await _DiseaseRepository.AddAsync(diseaseResult.Value);
        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateDiseaseCommandResult("error", "Add Disease has error and rollback is done");
        return new CreateDiseaseCommandResult("success", "ok");
    }
}
