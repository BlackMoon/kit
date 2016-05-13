using System.Linq;
using Microsoft.AspNet.Mvc.ModelBinding.Metadata;
using Microsoft.AspNet.Mvc.TagHelpers;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.AspNet.Razor.TagHelpers;

namespace Kit.Kernel.Web.TagHelpers
{
    /// <summary>
    /// TagHelper. Добавляет html-аттрибут [data-encrypt=true] свойству с аттрибутом EncryptDataTypeAttribute.
    /// </summary>
    [HtmlTargetElement("input", Attributes = "asp-for", TagStructure = TagStructure.WithoutEndTag)]
    public class EncryptInputTagHelper : InputTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            DefaultModelMetadata meta = (DefaultModelMetadata)For?.Metadata;
            if (meta != null &&
                meta.Attributes.PropertyAttributes.Any(a => a.GetType() == typeof(EncryptDataTypeAttribute)))
                output.Attributes.Add("data-encrypt", "true");

        }

        public EncryptInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }
    }
}
