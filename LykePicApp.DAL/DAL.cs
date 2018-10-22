using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public class DAL
    {
        public DataSet Create(string queryString, string connectionString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteDataset(sqlConn, queryString);
            }
        }

        public DataSet Retrieve(string queryString, string connectionString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteDataset(sqlConn, queryString);
            }
        }

        public DataSet Update(string queryString, string connectionString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteDataset(sqlConn, queryString);
            }
        }

        public DataSet Delete(string queryString, string connectionString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteDataset(sqlConn, queryString);
            }
        }
    }
}
