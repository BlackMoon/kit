using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Kit.Dal.DbManager;
using Mappings;
using Oracle.DataAccess.Client;

namespace Kit.Dal.Oracle
{
    [ProviderName("Oracle.DataAccess.Client")]
    public class OracleDbManager : IDbManager
    {
        private bool _wasClosed;

        /// <summary>
        /// DbConnection
        /// </summary>
        private OracleConnection _dbConnection;

        public IDbConnection DbConnection => _dbConnection = _dbConnection ?? new OracleConnection();
            
        /// <summary>
        /// DbContext
        /// </summary>
        private OracleContext _dbContext;

        public DbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    ExecuteNonQuery(CommandType.StoredProcedure, "SYS$INSTANCE.INIT");
                    _dbContext = new OracleContext(DbConnection, false);
                }

                return _dbContext;
            }
        }

        /// <summary>
        /// DbTransaction
        /// </summary>
        private OracleTransaction _transaction;

        public IDbTransaction Transaction => _transaction;

        public string ConnectionString { get; set; }
        
        public IDataReader DataReader { get; private set; }

        public IDbCommand DbCommand { get; private set; }

        public IDbDataParameter[] DataParameters { get; }

        public OracleDbManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void BeginTransaction()
        {
            _transaction = DbConnection.BeginTransaction() as OracleTransaction;
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction = null;
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
            // ReSharper disable once UseObjectOrCollectionInitializer
            DbCommand = new OracleCommand(commandText);
            DbCommand.Connection = DbConnection;

            return DataReader = DbCommand.ExecuteReader();
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            DbCommand = new OracleCommand(commandText);
            
            IDbDataAdapter dataAdapter = new OracleDataAdapter();
            dataAdapter.SelectCommand = DbCommand;

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DbCommand.Parameters.Clear();

            return dataSet;
        }

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            Open();

            DbCommand = new OracleCommand();
            PrepareCommand(DbCommand, DbConnection, Transaction, commandType, commandText, null);
            
            int returnValue = DbCommand.ExecuteNonQuery();
            DbCommand.Parameters.Clear();

            if (_wasClosed)
                DbConnection.Close();

            return returnValue;
        }

        public void CloseReader()
        {
            DataReader?.Close();
        }

        /// <summary>
        /// Закрыть соединение
        /// </summary>
        public void Close()
        {
            if (DbConnection.State != ConnectionState.Closed)
                DbConnection.Close();
        }

        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Close();

            _dbConnection = null;
            _dbContext = null;
            _transaction = null;
        }

#if ASYNC
        public Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (DbConnection.State != ConnectionState.Open)
            {
                DbConnection.ConnectionString = ConnectionString;
                return ((DbConnection)DbConnection).OpenAsync(cancellationToken);
            }
            return Task.FromResult(0);
        }
#endif
    }
}
