using System;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public class UserLike
    {
        public Guid LikeId { get; set; }

        public Guid UserId { get; set; }

        public Guid PostId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string GetInsertQuery()
        {
            return string.Format(@"INSERT INTO [dbo].[UserLikes]
               ([LikeId]
               ,[UserId]
               ,[PostId]
               ,[CreatedDate])
                 VALUES
                       (NEWID()
                       ,'{0}'
                       ,'{1}'
                       ,'{2}')", UserId, PostId, CreatedDate.ToString("yyyy-MM-dd"));
        }

        public string GetDeleteQuery()
        {
            return string.Format(@"DELETE FROM [dbo].[UserLikes] WHERE UserId='{0}' AND PostId='{1}'", UserId, PostId);
        }

        public static UserLike From(SqlDataReader reader)
        {
            return new UserLike()
            {
                LikeId = new Guid(reader["LikeId"].ToString()),
                UserId = new Guid(reader["UserId"].ToString()),
                PostId = new Guid(reader["FollowerUserId"].ToString()),
                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString())
            };
        }
    }
}