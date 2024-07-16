using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.ViewModels;

namespace WebApplication1.ActionResults
{
    public class CustomActionResult : IActionResult
    {
        private readonly CustomActionResultVM _result;

        public CustomActionResult(CustomActionResultVM result)
        {
            result = _result;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objextResult = new ObjectResult(_result.Exception ?? _result.Publisher as object)
            {
                StatusCode = _result.Exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };

            await objextResult.ExecuteResultAsync(context);
        }
    }
}
