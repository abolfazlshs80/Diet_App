﻿using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using Diet.Domain.food.Entities;
using Diet.Application.Interface;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Queries.GetAll;

public class GetAllFoodGroupQueryHandler : IQueryHandler<GetAllFoodGroupQuery,GetAllFoodGroupQueryResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFoodGroupQueryHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodGroupRepository = foodGroupRepository;
    }


    public async Task<ErrorOr<GetAllFoodGroupQueryResult>> Handle(GetAllFoodGroupQuery Query)
    {
        var result = await _foodGroupRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodGroupQueryResult(result.Count, result.Select(_ => new GetFoodGroupItem(_.Id,_.Title)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
