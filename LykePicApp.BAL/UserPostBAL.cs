using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserPostBAL : BaseBAL
    {
        public void Save(UserPost userPost)
        {
            if (userPost.PostId.Equals(Guid.Empty))
            {
                userPost.CreatedDate = DateTime.Now;
                DBContext.Create(userPost.GetInsertQuery());
            }
            else
            {
                DBContext.Update(userPost.GetUpdateQuery());
            }
        }

        public IList<UserPost> GetUserPosts(Guid userId)
        {
            var postList = new List<UserPost>();
            var queryString = string.Format(@"SELECT UP.* FROM dbo.UserPosts AS UP
                                                WHERE UserId='{0}'
                                                UNION
                                                SELECT UP.* FROM dbo.UserPosts AS UP
                                                INNER JOIN dbo.UserFollowers AS UF
                                                ON UP.UserId=UF.FollowerUserId
                                                WHERE UF.UserId='{0}'
                                                ", userId);
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    postList.Add(UserPost.From(reader));
                }
            }

            return postList;
        }

        public UserPost GetUserPost(Guid postId)
        {
            var queryString = string.Format("SELECT * FROM [dbo].[UserPosts] WHERE PostId='{0}'", postId);
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    return UserPost.From(reader);
                }
            }

            return null;
        }
    }
}
