using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;

namespace Kit.Dal.DbManager
{
    public partial interface IDbManager : IDisposable
    {
        string ConnectionString { get; set; }

        IDbConnection DbConnection { get; }

        DbContext DbContext { get; }

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
