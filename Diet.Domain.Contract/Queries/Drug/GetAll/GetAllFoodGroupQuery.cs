using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Drug.GetAll;

public record GetAllDrugQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

