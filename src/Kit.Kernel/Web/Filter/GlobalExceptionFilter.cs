using Kit.Kernel.Web.Ajax;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;

namespace Kit.Kernel.Web.Filter
{
    /// <summary>
    /// Фильтр для обработки глобальных исключений
    /// </summary>
    public class GlobalExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.IsAjax())
                context.Result = new JsonResult(new { context.Exception.Message });
        }
    }
}
