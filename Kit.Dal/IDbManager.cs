using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kit.Dal
{
    public interface IDbManager : IDisposable
    {
        string ConnectionString { get; set; }
        IDbConnection DbConnection { get; }
        IDbTransaction Transaction { get; }
        IDataReader DataReader { get; }
        IDbCommand DbCommand { get; }
        IDbDataParameter[] DataParameters { get; }
        void Open();
        void BeginTransaction();
        void CommitTransaction();
        void CreateParameters(int paramsCount);
        void AddParameters(int index, string paramName, object objValue);
        IDataReader ExecuteReader(CommandType commandType, string commandText);
        DataSet ExecuteDataSet(CommandType commandType, string commandText);
        object ExecuteScalar(CommandType commandType, string commandText);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        void CloseReader();
        void Close();
    }
}
