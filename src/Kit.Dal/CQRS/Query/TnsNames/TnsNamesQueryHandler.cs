using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using Kit.Kernel.Cache;
using Kit.Kernel.CQRS.Query;
using Kit.Kernel.Interception.Attribute;

namespace Kit.Dal.CQRS.Query.TnsNames
{
    /// <summary>
    /// Получает список tnsnames из ORACLE_HOME (файл TNSNAMES.ORA).
    /// <para>Необходимо наличие OraOps.dll</para>
    /// </summary>
    [InterceptedObject(InterceptorType = typeof(CacheInterceptor), ServiceInterfaceType = typeof(IQueryHandler<TnsNamesQuery, TnsNamesQueryResult>))]
    public class TnsNamesQueryHandler : IQueryHandler<TnsNamesQuery, TnsNamesQueryResult>
    {
        public TnsNamesQueryResult Execute(TnsNamesQuery query)
        {
            if (string.IsNullOrEmpty(query.ProviderInvariantName))
                throw new ArgumentNullException(nameof(query.ProviderInvariantName));

            TnsNamesQueryResult tnsNames = new TnsNamesQueryResult();
           
            DbProviderFactory factory = DbProviderFactories.GetFactory(query.ProviderInvariantName);

            if (factory.CanCreateDataSourceEnumerator)
            {
                DbDataSourceEnumerator dsenum = factory.CreateDataSourceEnumerator();
                if (dsenum != null)
                {
                    DataTable dt = dsenum.GetDataSources();
                    DataRow[] rows = dt.Select(null, "InstanceName", DataViewRowState.CurrentRows);

                    tnsNames.AddRange(rows.Select(row => (string) row["InstanceName"]));
                }
            }

            return tnsNames;
        }
    }
}
