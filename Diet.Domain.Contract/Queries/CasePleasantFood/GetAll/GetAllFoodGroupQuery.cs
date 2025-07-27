using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CasePleasantFood.GetAll;

public record GetAllCasePleasantFoodQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

