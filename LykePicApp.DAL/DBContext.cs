using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public static class DBContext
    {
        public static int Create(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteNonQuery(sqlConn, CommandType.Text, queryString);
            }
        }

        public static DataSet RetrieveDataSet(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteDataset(sqlConn, CommandType.Text, queryString);
            }
        }

        public static SqlDataReader RetrieveDataReader(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);
            }
        }

        public static int Update(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteNonQuery(sqlConn, CommandType.Text, queryString);
            }
        }

        public static int Delete(string queryString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                return SqlHelper.ExecuteNonQuery(sqlConn, CommandType.Text, queryString);
            }
        }
    }
}
