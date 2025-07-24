using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodDrugIntraction.GetAll;

public record GetAllFoodDrugIntractionQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

