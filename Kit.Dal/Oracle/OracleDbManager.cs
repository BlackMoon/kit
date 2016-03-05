using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace Kit.Dal.Oracle
{
    [ProviderName("Oracle.DataAccess.Client")]
    public class OracleDbManager : IDbManager
    {
        public string ConnectionString { get; set; }
        public IDbConnection DbConnection { get; private set; }
        public IDbTransaction Transaction { get; private set; }
        public IDataReader DataReader { get; }
        public IDbCommand DbCommand { get; private set; }
        public IDbDataParameter[] DataParameters { get; }

        public OracleDbManager(string connectionString)
        {
            ConnectionString = connectionString;

            DbConnection = new OracleConnection(ConnectionString);
        }
        
        public void Open()
        {
            if (DbConnection.State != ConnectionState.Open)
                DbConnection.Open();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void CreateParameters(int paramsCount)
        {
            throw new NotImplementedException();
        }

        public void AddParameters(int index, string paramName, object objValue)
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            throw new NotImplementedException();
        }

        public void CloseReader()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Close();
            DbCommand = null;
            Transaction = null;
            DbConnection = null;
        }
    }
}
