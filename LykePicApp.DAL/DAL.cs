using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public static class DAL
    {
        public static int Create(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteNonQuery(sqlConn, queryString);
            }
        }

        public static DataSet RetrieveDataSet(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteDataset(sqlConn, queryString);
            }
        }

        public static int Update(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteNonQuery(sqlConn, queryString);
            }
        }

        public static int Delete(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteNonQuery(sqlConn, queryString);
            }
        }
    }
}
