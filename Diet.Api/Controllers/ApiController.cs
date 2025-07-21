
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Diet.Api.Http;

namespace Diet.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];
            if (errors.Count is 0)
            {
                return Problem();
            }

            return Problem(statusCode: StatusCodes.Status400BadRequest, title: firstError.Code + " => " + firstError.Description);
        }
    }
}
