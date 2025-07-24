using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodStuff.GetAll;

public record GetAllFoodStuffQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

