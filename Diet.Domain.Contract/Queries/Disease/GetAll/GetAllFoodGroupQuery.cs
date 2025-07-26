using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Disease.GetAll;

public record GetAllDiseaseQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

