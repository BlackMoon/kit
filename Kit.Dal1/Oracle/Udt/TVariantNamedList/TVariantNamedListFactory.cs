using System.Diagnostics.CodeAnalysis;
using Kit.Dal.Oracle.Udt.TVariantNamedList;
using Oracle.DataAccess.Types;

/// <summary>
/// Summary description for TVariantNamedListFactory
/// </summary>
[OracleCustomTypeMappingAttribute("T_VARIANT_NAMED_LIST")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class VariantNamedListFactory : IOracleCustomTypeFactory
{
    public IOracleCustomType CreateObject()
    {
        return TVariantNamedList.Create();
    }
}