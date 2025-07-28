using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.recommendation.Repository;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Commands.Create;

public class CreateSupplementDisease_WhiteListCommandHandler : ICommandHandler<CreateSupplementDisease_WhiteListCommand, CreateSupplementDisease_WhiteListCommandResult>
{
    private readonly ISupplementDisease_WhiteListRepository _supplementDisease_WhiteListRepository;
    private readonly ISupplementRepository _supplementRepository;
    private readonly IDiseaseRepository _diseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementDisease_WhiteListCommandHandler(ISupplementDisease_WhiteListRepository supplementDisease_WhiteListRepository,

        ISupplementRepository supplementRepository,
        IDiseaseRepository diseaseRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDisease_WhiteListRepository = supplementDisease_WhiteListRepository;
        _supplementRepository = supplementRepository;
        _diseaseRepository = diseaseRepository;
    }

    public async Task<ErrorOr<CreateSupplementDisease_WhiteListCommandResult>> Handle(CreateSupplementDisease_WhiteListCommand command)
    {
        if (!await _supplementRepository.IsExists(command.SupplementId))
            return new CreateSupplementDisease_WhiteListCommandResult("error", "SupplementId is not Exists");
        if (!await _diseaseRepository.IsExists(command.DiseaseId))
            return new CreateSupplementDisease_WhiteListCommandResult("error", "DiseaseId is not Exists");

        var result = Domain.supplementDisease_WhiteList.SupplementDisease_WhiteList.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementDisease_WhiteListRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSupplementDisease_WhiteListCommandResult("error", "Add SupplementDisease_WhiteList has error and rollback is done");

        return new CreateSupplementDisease_WhiteListCommandResult("success", "ok");
    }
}
