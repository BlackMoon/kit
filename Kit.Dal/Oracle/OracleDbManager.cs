using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Kit.Dal.DbManager;
using Oracle.DataAccess.Client;

namespace Kit.Dal.Oracle
{
    [ProviderName("Oracle.DataAccess.Client")]
    public class OracleDbManager : IDbManager
    {
        private IDbConnection _dbConnection;

        public IDbConnection DbConnection
        {
            get
            {
                return _dbConnection = _dbConnection ?? new OracleConnection();
            }
        }

        public string ConnectionString { get; set; }

        public IDbTransaction Transaction { get; private set; }
        public IDataReader DataReader { get; }

        public IDbCommand DbCommand { get; private set; }
        public IDbDataParameter[] DataParameters { get; }

        public OracleDbManager(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        public void Open()
        {
            if (DbConnection.State != ConnectionState.Open)
            {
                DbConnection.ConnectionString = ConnectionString;
                DbConnection.Open();
            }
        }

        public Task OpenAsync()
        {
            if (DbConnection.State != ConnectionState.Open)
            {
                DbConnection.ConnectionString = ConnectionString;
                return (DbConnection as OracleConnection)?.OpenAsync();
            }
            return Task.FromResult(0);
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
            _dbConnection = null;
        }
    }
}
