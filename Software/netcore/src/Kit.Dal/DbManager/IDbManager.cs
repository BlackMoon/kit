using System;
using System.Data;
using System.Data.Entity;

namespace Kit.Dal.DbManager
{
    public interface IDbManager : IDisposable
    {
        string ConnectionString { get; set; }

        IDbConnection DbConnection { get; }
#if DBCONTEXT
        DbContext DbContext { get; }
#endif        
        IDbTransaction Transaction { get; }
        IDataReader DataReader { get; }
        IDbCommand DbCommand { get; }
        IDbDataParameter[] DataParameters { get; }
        void Open();
        void Open(string connectionString);
        void OpenWithNewPassword(string newPassword);
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
