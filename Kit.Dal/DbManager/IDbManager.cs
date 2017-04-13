using System;
using System.Data;

namespace Kit.Dal.DbManager
{
    public interface IDbManager : IDisposable
    {
        string ConnectionString { get; set; }

        IDbConnection DbConnection { get; }
        IDbTransaction Transaction { get; }
        IDataReader DataReader { get; }
        IDbCommand DbCommand { get; }
        IDbDataParameter[] DbParameters { get; }

        /// <summary>
        /// Set this property to log the SQL
        /// </summary>
        Action<string> Log { get; set; }

        /// <summary>
        /// Occurs on NotificationResponses from the backend.
        /// </summary>
        Action<object, EventArgs> Notification { get; set; }

        void AddParameter(IDbDataParameter dataParameter);
        IDbDataParameter AddParameter(string name, object value);
        IDbDataParameter AddParameter(string name, object value, ParameterDirection direction);
        IDbDataParameter AddParameter(string name, object value, ParameterDirection direction, int size);
        void Open();
        void Open(string connectionString);
        void OpenWithNewPassword(string newPassword);
        void BeginTransaction();
        void CommitTransaction();
        IDataReader ExecuteReader(CommandType commandType, string commandText);

#if NET46
        DataSet ExecuteDataSet(CommandType commandType, string commandText);
#endif
        object ExecuteScalar(CommandType commandType, string commandText);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        void CloseReader();
        void Close();
    }
}
