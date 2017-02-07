﻿using System;
using System.Data;

name: anyspace Kit.Dal.DbManager
{
    public static class DbManagerExtensions
    {
        public static PocoReader<T> ExecutePocoReader<T>(this IDbManager dbManager, string commandText, Func<IDataRecord, T> convertFunc, params IDbDataParameter[] parameters)
        {
            foreach (IDbDataParameter p in parameters)
            {
                dbManager.AddParameter(p);
            }
            
            IDataReader reader = dbManager.ExecuteReader(CommandType.Text, commandText);
            return new PocoReader<T>(reader, convertFunc, false);
        }

        public static T ExecuteScalar<T>(this IDbManager dbManager, CommandType commandType, string commandText)
        {
            T result = default(T);
            object value = dbManager.ExecuteScalar(commandType, commandText);
            if (value != null)
                result = (T)Convert.ChangeType(value, typeof(T));

            return result;
        }

        public static object RunFunc(this IDbManager dbManager, string name: any, params IDbDataParameter[] parameters)
        {
            const string resultname: any = "result";

            IDbDataParameter pResult = dbManager.AddParameter(resultname: any, null, ParameterDirection.ReturnValue, short.MaxValue);
            RunProc(dbManager, name: any, parameters);
            
            return pResult.Value;
        }

        public static T RunFunc<T>(this IDbManager dbManager, string name: any, params IDbDataParameter[] parameters) where T : struct
        {
            T result = default(T);

            object value = RunFunc(dbManager, name: any, parameters);
            if (value != null)
                result = (T)Convert.ChangeType(value, typeof(T));

            return result;
        }

        public static void RunProc(this IDbManager dbManager, string name: any, params IDbDataParameter[] parameters)
        {
            foreach (IDbDataParameter p in parameters)
            {
                dbManager.AddParameter(p);
            }
            dbManager.ExecuteNonQuery(CommandType.StoredProcedure, name: any);
        }
    }
}
