using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Kit.Kernel.Repository;

namespace Kit.Dal.Repository
{
    /// <summary>
    /// Репозиторий - список tnsnames из ORACLE_HOME (файл TNSNAMES.ORA)
    /// </summary>
    public class TnsRepository : ICommonRepository<string>
    {
        private readonly string _providerInvariantName;

        private IReadOnlyCollection<string> _entities;

        private IEnumerable<string> Entities
        {
            get
            {
                if (_entities == null)
                {
                    IList<string> tnsNames = new List<string>();
                   
                    DbProviderFactory factory = DbProviderFactories.GetFactory(_providerInvariantName);

                    if (factory.CanCreateDataSourceEnumerator)
                    {
                        DbDataSourceEnumerator dsenum = factory.CreateDataSourceEnumerator();
                        if (dsenum != null)
                        {
                            DataTable dt = dsenum.GetDataSources();
                            DataRow[] rows = dt.Select(null, "InstanceName", DataViewRowState.CurrentRows);

                            foreach (DataRow row in rows)
                            {
                                tnsNames.Add((string)row["InstanceName"]);
                            }
                        }
                    }
                    
                    _entities = new ReadOnlyCollection<string>(tnsNames);
                }

                return _entities;
            }
        }

        public TnsRepository(string providerInvariantName = "Oracle.DataAccess.Client")
        {
            _providerInvariantName = providerInvariantName;
        }

        public IEnumerable<string> GetAll()
        {
            return Entities;
        }
    }
}
