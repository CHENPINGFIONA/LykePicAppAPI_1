using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LykePicApp.DAL
{
    public class UserFollower
    {
        public Guid UserId { get; set; }

        public Guid FollowerUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string GetInsertQuery()
        {
            return string.Format(@"INSERT INTO [dbo].[UserFollowers]
               ([UserId]
               ,[FollowerUserId]
               ,[CreatedDate])
                 VALUES
                       ('{0}'
                       ,'{1}'
                       ,'{2}')", UserId, FollowerUserId, CreatedDate.ToString("yyyy-MM-dd"));
        }

        public string GetDeleteQuery()
        {
            return string.Format(@"DELETE FROM [dbo].[UserFollowers] WHERE UserId='{0}' AND FollowerUserId='{1}'", UserId, FollowerUserId);
        }

        public static UserFollower From(SqlDataReader reader)
        {
            return new UserFollower()
            {
                UserId = new Guid(reader["UserId"].ToString()),
                FollowerUserId = new Guid(reader["FollowerUserId"].ToString()),
                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString())
            };
        }
    }
}