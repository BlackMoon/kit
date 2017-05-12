using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Kit.Core.Web.Binders
{
    /// <summary>
    /// Провайдер InvariantDecimalModelBinder'a
    /// </summary>
    public class InvariantDecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Type [] floatingPointTypes =
            {
                typeof(decimal),
                typeof(decimal?),
                typeof(double),
                typeof(double?),
                typeof(float),
                typeof(float?),
            };
            
            if (!context.Metadata.IsComplexType && floatingPointTypes.Contains(context.Metadata.ModelType))
                return new InvariantDecimalModelBinder(context.Metadata.ModelType);

            return null;
        }
    }
}
