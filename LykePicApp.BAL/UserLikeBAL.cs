using LykePicApp.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.BAL
{
    public class UserLikeBAL : BaseBAL
    {
        public void Like(Guid userId, Guid postId)
        {
            var userLike = new UserLike()
            {
                UserId = userId,
                PostId = postId,
                CreatedDate = DateTime.Now
            };

            DBContext.Create(userLike.GetInsertQuery());
        }

        public void DisLikePost(Guid userId, Guid postId)
        {
            var userLike = new UserLike()
            {
                UserId = userId,
                PostId = postId
            };

            DBContext.Delete(userLike.GetDeleteQuery());
        }

        private UserLike GetUserLike(Guid userId, Guid postId)
        {
            var queryString = string.Format("SELECT * FROM [dbo].[UserLikes] WHERE UserId='{0} AND PostId='{1}'", userId, postId);
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    return UserLike.From(reader);
                }
            }

            return null;
        }
    }
}
