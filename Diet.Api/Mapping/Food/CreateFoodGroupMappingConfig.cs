
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.FoodGroup;
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using Mapster;

namespace FoodGroup.Api.Mapping.FoodGroup;

public class CreateFoodGroupMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<CreateFoodGroupDto, CreateFoodGroupCommand>();
        //config.NewConfig<DeleteFoodGroupDto, DeleteFoodGroupCommand>();
        //config.NewConfig<UpdateFoodGroupDto, UpdateFoodGroupCommand>();
        //config.NewConfig<GetAllFoodGroupDto, GetAllFoodGroupQuery>();
        //config.NewConfig<GetByIdFoodGroupDto, GetByIdFoodGroupQuery>();
        
    }
}

