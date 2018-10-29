using System;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public class UserPost
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string GetInsertQuery()
        {
            return string.Format(@"INSERT INTO [dbo].[UserPosts]
               ([PostId]
               ,[UserId]
               ,[Picture]
               ,[Description]
               ,[CreatedDate])
                 VALUES
                       (NEWID()
                       ,'{0}'
                       ,'{1}'
                       ,'{2}'
                       ,'{3}')", UserId, Picture, Description, CreatedDate.ToString("yyyy-MM-dd"));
        }

        public string GetUpdateQuery()
        {
            return string.Format(@"UPDATE [dbo].[UserPosts]
           SET [UserId] = '{0}'
              ,[Picture] = '{1}'
              ,[Description] = '{2}'
              WHERE PostId='{3}'", UserId, Picture, Description, UserId);
        }

        public static UserPost From(SqlDataReader reader)
        {
            return new UserPost()
            {
                PostId = new Guid(reader["PostId"].ToString()),
                UserId = new Guid(reader["UserId"].ToString()),
                Picture = reader["Picture"].ToString(),
                Description = reader["Description"].ToString(),
                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString())
            };
        }
    }
}