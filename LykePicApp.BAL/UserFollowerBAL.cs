using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.BAL
{
    public class UserFollowerBAL : BaseBAL
    {
        public void Follow(Guid userId, Guid followerUserId)
        {
            AddUser(userId, followerUserId);
            AddUser(followerUserId, userId);
        }

        public void UnFollow(Guid userId, Guid followerUserId)
        {
            RemoveUser(userId, followerUserId);
            RemoveUser(followerUserId, userId);
        }

        public IList<User> GetFollowUserList(Guid userId)
        {
            var userList = new List<User>();
            var queryString = string.Format(@"SELECT U.* FROM dbo.Users AS U
                                                INNER JOIN dbo.UserFollowers AS UF
                                                ON U.UserId=UF.FollowerUserId
                                                WHERE UF.UserId='{0}'", userId);

            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    userList.Add(User.From(reader));
                }
            }

            return userList;
        }

        private UserFollower GetUserFollower(Guid userId, Guid followerUserId)
        {
            var queryString = string.Format("SELECT * FROM [dbo].[UserFollowers] WHERE UserId='{0}' AND FollowerUserId={1}", userId, followerUserId);
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    return UserFollower.From(reader);
                }
            }

            return null;
        }

        private void AddUser(Guid userId, Guid followerUserId)
        {
            var userFollower = new UserFollower()
            {
                UserId = userId,
                FollowerUserId = followerUserId,
                CreatedDate = DateTime.Now
            };

            DBContext.Create(userFollower.GetInsertQuery());
        }

        private void RemoveUser(Guid userId, Guid followerUserId)
        {
            var userFollower = new UserFollower()
            {
                UserId = userId,
                FollowerUserId = followerUserId,
            };

            DBContext.Delete(userFollower.GetDeleteQuery());
        }
    }
}
