using System;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders;

namespace Kit.Kernel.Web.HtmlHelper
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Конвертирует c# enum в js enum
        ///  </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="t">Тип enum</param>
        /// <param name="addScriptTags">Добавлять теги &lt;script&gt;&lt;/script&gt;</param>
        /// <returns></returns>
        public static HtmlString EnumToJs(this IHtmlHelper htmlHelper, Type t, bool addScriptTags = false)
        {
            if (!t.IsEnum)
                throw new InvalidOperationException("Type is not Enum");

            StringBuilder sb = new StringBuilder($"var {t.Name} = ");
            sb.AppendLine("{" + string.Join(", ",
                Enum.GetValues(t)
                    .Cast<int>()
                    .Select(v => Enum.GetName(t, v) + ": " + v)) + "};");

            HtmlString htmlString;
            if (addScriptTags)
            {
                TagBuilder link = new TagBuilder("script");
                link.MergeAttribute("type", "text/javascript");
                link.InnerHtml.AppendHtml(sb.ToString());

                var sw = new System.IO.StringWriter();
                link.WriteTo(sw, new HtmlEncoder());

                htmlString = new HtmlString(sw.ToString());
            }
            else
                htmlString = new HtmlString(sb.ToString());

            return htmlString;
        }
    }
}
