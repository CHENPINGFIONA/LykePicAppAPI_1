using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public class DatabaseHelper
    {
        public static SqlConnection GetConnection(string instance)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[instance].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }

        public static SqlConnection GetConnection()
        {
            return GetConnection("conn");
        }
    }
}
