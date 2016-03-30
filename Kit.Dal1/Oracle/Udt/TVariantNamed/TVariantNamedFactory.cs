﻿using System.Diagnostics.CodeAnalysis;
using Oracle.DataAccess.Types;

namespace Kit.Dal.Oracle.Udt.TVariantNamed
{
    /// <summary>
    /// Summary description for TVariantNamedFactory
    /// </summary>
    [OracleCustomTypeMapping("T_VARIANT_NAMED")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TVariantNamedFactory : IOracleCustomTypeFactory
    {
	
        public IOracleCustomType CreateObject()
        {
            return new TVariantNamed();
        }
    }
}