using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykePicApp.BAL
{
    public class DAL
    {
        public DataSet Execute(string queryString, string connectionString)
        {
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                SqlParameter[] sqlParams = SqlParamCache.GetParameterSet(sqlConn, ANNOUNCEMENT_TASK_LIST);

                sqlParams[0].Value = userId;
                sqlParams[1].Value = name;
                sqlParams[2].Value = readType;
                sqlParams[3].Value = pageIndex;
                sqlParams[4].Value = pageSize;

                return SqlHelper.ExecuteDataset(sqlConn, ANNOUNCEMENT_TASK_LIST, sqlParams);
            }
        }
    }
}
