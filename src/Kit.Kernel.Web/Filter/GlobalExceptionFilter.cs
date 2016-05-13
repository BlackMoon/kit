using Kit.Kernel.Web.Http.Ajax;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;

namespace Kit.Kernel.Web.Filter
{
    /// <summary>
    /// Фильтр для обработки глобальных исключений
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.IsAjax())
                context.Result = new ObjectResult(new { context.Exception.Message, context.Exception.StackTrace }) { StatusCode = 500 };
        }
    }
}
