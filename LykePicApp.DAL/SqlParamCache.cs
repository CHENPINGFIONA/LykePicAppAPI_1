using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{

    public sealed class SqlParamCache
    {
        private static IDictionary<string, SqlParameter[]> paramCache = new Dictionary<string, SqlParameter[]>();

        private static string GetKey(SqlConnection connection, string spName)
        {
            return string.Format("{0}:{1}", connection.ConnectionString, spName);
        }

        private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            if (spName == null || spName.Length == 0)
            {
                throw new ArgumentNullException("spName");
            }

            SqlCommand cmd = null;
            if (transaction != null)
            {
                cmd = new SqlCommand(spName, connection, transaction);
            }
            else
            {
                cmd = new SqlCommand(spName, connection);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);

            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
            cmd.Parameters.CopyTo(discoveredParameters, 0);

            foreach (SqlParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }

            return discoveredParameters;
        }

        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        private static SqlParameter[] GetParameterSetInternal(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            if (spName == null || spName.Length == 0)
            {
                throw new ArgumentNullException("spName");
            }

            string key = GetKey(connection, spName);
            if (!paramCache.ContainsKey(key))
            {
                SqlParameter[] spParameters = DiscoverSpParameterSet(connection, transaction, spName, includeReturnValueParameter);
                paramCache[key] = spParameters;
            }

            return CloneParameters(paramCache[key]);
        }

        public static SqlParameter[] GetCachedParameterSet(SqlConnection connection, string spName)
        {
            if (spName == null || spName.Length == 0)
            {
                throw new ArgumentNullException("spName");
            }

            string key = GetKey(connection, spName);
            if (paramCache.ContainsKey(key))
            {
                return CloneParameters(paramCache[key]);
            }

            return null;
        }

        public static SqlParameter[] GetParameterSet(SqlConnection connection, string spName)
        {
            SqlParameter[] sqlParams = GetCachedParameterSet(connection, spName);
            if (sqlParams == null)
            {
                sqlParams = GetParameterSet(connection, null, spName, false);
            }

            return sqlParams;
        }

        public static SqlParameter[] GetParameterSet(SqlConnection connection, SqlTransaction transaction, string spName)
        {
            return GetParameterSet(connection, transaction, spName, false);
        }

        public static SqlParameter[] GetParameterSet(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
        {
            if (spName == null || spName.Length == 0)
            {
                throw new ArgumentNullException("spName");
            }

            return GetParameterSetInternal(connection, transaction, spName, includeReturnValueParameter);
        }
    }
}
