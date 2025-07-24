using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodFoodIntraction.GetAll;

public record GetAllFoodFoodIntractionQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

