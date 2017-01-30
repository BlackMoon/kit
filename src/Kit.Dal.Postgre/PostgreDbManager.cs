using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Kit.Dal.DbManager;
using Npgsql;

namespace Kit.Dal.PostgreSQL
{
    [ProviderName("Npgsql")]
    public class PostgreDbManager : IDbManager, IDbManagerAsync
    {
        private bool _wasClosed;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Close();
            
            _dbConnection = null;
        }

        public string ConnectionString { get; set; }

        /// <summary>
        /// DbConnection
        /// </summary>
        private NpgsqlConnection _dbConnection;

        public IDbConnection DbConnection => _dbConnection = _dbConnection ?? new NpgsqlConnection();
        
        public IDbTransaction Transaction { get; }
        public IDataReader DataReader { get; }
        public IDbCommand DbCommand { get; }
        public IDbDataParameter[] DbParameters { get; }
        public void AddParameter(IDbDataParameter dataParameter)
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter AddParameter(string name, object value)
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter AddParameter(string name, object value, ParameterDirection direction)
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter AddParameter(string name, object value, ParameterDirection direction, int size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Открыть соединение
        /// </summary>
        public void Open()
        {
            _wasClosed = (DbConnection.State == ConnectionState.Closed);
            if (_wasClosed)
            {
                DbConnection.ConnectionString = ConnectionString;
                DbConnection.Open();
            }
        }

        public void Open(string connectionString)
        {
            ConnectionString = connectionString;
            Open();
        }

        /// <summary>
        /// Открыть асинхронное соединение
        /// </summary>
        public Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (DbConnection.State != ConnectionState.Open)
            {
                DbConnection.ConnectionString = ConnectionString;
                return ((DbConnection)DbConnection).OpenAsync(cancellationToken);
            }
            return Task.FromResult(0);
        }

        public void OpenWithNewPassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
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

        /// <summary>
        /// Закрыть соединение
        /// </summary>
        public void Close()
        {
            if (DbConnection.State != ConnectionState.Closed)
                DbConnection.Close();
        }
    }
}
