using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Framework.Core.Bus;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("FoodGroup")]
public class FoodGroupController : ApiController
{
    private readonly ICommandBus _commandBus;
  


    public FoodGroupController(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    
    }

    [HttpPost(nameof(CreateFoodGroup))]
    public async Task<IActionResult> CreateFoodGroup(CreateFoodGroupCommand request)
    {
       // var createFoodGroupCommand = _mapper.Map<CreateFoodGroupCommand>(request);
         
        var createFoodGroupResult =
            await _commandBus.Send<CreateFoodGroupCommand, CreateFoodGroupCommandResult>(request);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

