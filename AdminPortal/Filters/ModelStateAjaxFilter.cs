using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace AdminPortal.Filters
{
    public class ModelStateAjaxFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
