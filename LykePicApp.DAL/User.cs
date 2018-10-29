using System;
using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.DAL
{
    public class User
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime CreatedDate { get; set; }

        public string GetInsertQuery()
        {
            return string.Format(@"INSERT INTO [dbo].[Users]
               ([UserId]
               ,[UserName]
               ,[Email]
               ,[Password]
               ,[ProfilePicture]
               ,[CreatedDate])
                 VALUES
                       (NEWID()
                       ,'{0}'
                       ,'{1}'
                       ,'{2}'
                       ,'{3}'
                       ,'{4}')", UserName, Email, Password, ProfilePicture, CreatedDate.ToString("yyyy-MM-dd"));
        }

        public string GetUpdateQuery()
        {
            return string.Format(@"UPDATE [dbo].[Users]
           SET [UserName] = '{0}'
              ,[Email] = '{1}'
              ,[Password] = '{2}'
              ,[ProfilePicture] = '{3}'
              WHERE UserId='{4}'", UserName, Email, Password, ProfilePicture, UserId);
        }

        public static User From(SqlDataReader reader)
        {
            return new User()
            {
                UserId = new Guid(reader["UserId"].ToString()),
                UserName = reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                ProfilePicture = reader["ProfilePicture"].ToString(),
                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString())
            };
        }
    }
}