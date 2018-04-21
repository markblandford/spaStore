namespace SpaStore.Utils
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary> Catches <see cref="ActionResultException"/> exceptions thrown
    /// from controller actions and turns them into suitable <see cref="IActionResult"/>
    /// responses. This makes it possible for controller actions to return model
    /// objects rather than <see cref="IActionResult"/>. </summary>
    public class ActionResultExceptionFilter : IAsyncActionFilter
    {
        /// <inheritdoc />
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext executedContext = await next();
            if (executedContext.Exception is ActionResultException actionResultException && !executedContext.Canceled && !executedContext.ExceptionHandled)
            {
                executedContext.Exception = null;
                executedContext.Result = actionResultException.Result;
            }
        }
    }
}
