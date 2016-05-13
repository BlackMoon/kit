using Kit.Kernel.Web.Http;
using Kit.Kernel.Web.Http.Ajax;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;

namespace Kit.Kernel.Web.Mvc.Filter
{
    /// <summary>
    /// Фильтр для обработки глобальных исключений
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Microsoft.AspNet.Http.HttpRequest request = context.HttpContext.Request;
            if (request.IsAjax())
            {
                context.Result = new ObjectResult(new { context.Exception.Message, context.Exception.StackTrace }) { StatusCode = 500 };

                //Для Internet Explorer 8 заменяет contentType = text / html вместо application/ json
                if (request.IsIe8())
                    context.HttpContext.Response.ContentType = "text/html";
            }
        }
    }
}
