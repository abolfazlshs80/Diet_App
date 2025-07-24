using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Food.GetAll;

public record GetAllFoodQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

