using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Kit.Kernel.Web.EncryptData
{
    /// <summary>
    /// ModelBinder для дешифрования EncryptedDataType свойств
    /// </summary>
    /*public class EncryptModelBinder : MutableObjectModelBinder
    {
        protected override void SetProperty(ModelBindingContext bindingContext, ModelMetadata metadata, ModelMetadata propertyMetadata, ModelBindingResult result)
        {
            DefaultModelMetadata meta = (DefaultModelMetadata)propertyMetadata;
            if (meta != null && meta.Attributes.PropertyAttributes.Any(a => a.GetType() == typeof(EncryptDataTypeAttribute)))
            {
                string value = (string)result.Model ?? string.Empty;

                // xor decode
                char[] buff = value.ToCharArray();
                for (int i = 0; i < value.Length; ++i)
                {
                    buff[i] = (char)(value[i] ^ 128);
                }
                result = ModelBindingResult.Success(result.Key, new string(buff));
            }

            base.SetProperty(bindingContext, metadata, propertyMetadata, result);
        }
    }*/
}
