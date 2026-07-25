
using ecommerce.app.common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIbasecontoller : ControllerBase
    {


        public static ActionResult<T>ToActionResult<T>(Result<T> results){
            if (results.IsSuccess) { return new OkObjectResult(results.data);
            }
            return ToProblem(results.Errors);
        }

        public static ActionResult ToActionResult(Result results)
        {
            if (results.IsSuccess)
            {
                return new OkResult();
            }
            return ToProblem(results.Errors);
        }

        private static ObjectResult ToProblem(IReadOnlyList<error> errors)
        {
            var first = errors[0];

            var status = first.Type switch
            {
                errortype.notfound => StatusCodes.Status404NotFound
, errortype.validation => StatusCodes.Status400BadRequest, errortype.conflict => StatusCodes.Status409Conflict, errortype.unauthorized => StatusCodes.Status401Unauthorized, errortype.forbidden => StatusCodes.Status403Forbidden
, _ => StatusCodes.Status500InternalServerError
            };
            var prolem = new ProblemDetails
            {
                Status = status,
                Title = first.codems,
                Detail = first.message,
                Extensions = { ["errors"] = errors }
            };
            return new ObjectResult(prolem) { StatusCode= status };
        }

        protected string GetEmailFromToken()
    => User.FindFirstValue(ClaimTypes.Email)
    ?? throw new UnauthorizedAccessException("No Email Claim Found");

    }
}
