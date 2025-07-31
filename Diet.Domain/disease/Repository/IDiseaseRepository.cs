using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.Disease;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.disease.Repository;

public interface IDiseaseRepository: IRepository
{

    Task<List<GetItemDiseaseDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Disease> ByIdAsync(Guid Id);
    Task<GetItemDiseaseDto> ByIdDtoAsync(Guid Id);

    Task<bool> IsExists(Guid Id);
    Task AddAsync(Disease Disease);
    void Update(Disease Disease);
    void Delete(Disease Disease);
}
