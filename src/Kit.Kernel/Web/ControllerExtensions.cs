using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewEngines;
using Microsoft.AspNet.Mvc.ViewFeatures;

namespace Kit.Kernel.Web
{
    public static class ControllerExtensions
    {
        public static string RenderPartialViewToString(this Controller controller, string viewName)
        {
            return controller.RenderPartialViewToString(viewName, null);
        }

        /// <summary>
        /// Render view в строку
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string RenderPartialViewToString(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ActionContext.ActionDescriptor.Name;

            controller.ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ICompositeViewEngine engine = controller.Resolver.GetService<ICompositeViewEngine>();
                ViewEngineResult viewResult = engine.FindPartialView(controller.ActionContext, viewName);

                ViewContext viewContext = new ViewContext(controller.ActionContext, viewResult.View, controller.ViewData, controller.TempData, sw, new HtmlHelperOptions());
                Task task = viewResult.View.RenderAsync(viewContext);
                task.Wait();

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
