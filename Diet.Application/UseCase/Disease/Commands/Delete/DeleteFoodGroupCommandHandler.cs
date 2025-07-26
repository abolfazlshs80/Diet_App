
using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.disease.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Disease.Domain.Disease.Errors.DomainErrors;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Disease.Commands.Delete;

public class DeleteDiseaseCommandHandler : ICommandHandler<DeleteDiseaseCommand, DeleteDiseaseCommandResult>
{
    private readonly IDiseaseRepository _DiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDiseaseCommandHandler(IDiseaseRepository DiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DiseaseRepository = DiseaseRepository;
    }


    public async Task<ErrorOr<DeleteDiseaseCommandResult>> Handle(DeleteDiseaseCommand command)
    {
        var result = await _DiseaseRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteDiseaseCommandResult("errorFound", " not found desaised ");

        await _unitOfWork.BeginTransactionAsync();
        await _DiseaseRepository.DeleteAsync(result);
        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteDiseaseCommandResult("error", "Delete Disease has error and rollback is done");
        return new DeleteDiseaseCommandResult("success", "ok");
    }
}
