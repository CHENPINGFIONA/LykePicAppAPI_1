using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LykePicApp.BAL
{
    public class UserBAL : BaseBAL
    {
        public User Login(string userName, string password)
        {
            var user = GetUserByName(userName);
            if (user != null && user.Password.Equals(password))
            {
                return user;
            }

            return null;
        }

        public UserBAL Save(User user)
        {
            if (user.UserId.Equals(Guid.Empty))
            {
                ValidateUserExist(user.UserName);

                user.CreatedDate = DateTime.Now;
                DBContext.Create(user.GetInsertQuery());
            }
            else
            {
                DBContext.Update(user.GetUpdateQuery());
            }

            return this;
        }

        public User GetUserById(Guid userId)
        {
            var queryString = string.Format("SELECT * FROM [dbo].[Users] WHERE UserId='{0}'", userId);
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    return User.From(reader);
                }
            }

            return null;
        }

        public User GetUserByName(string userName)
        {
            var queryString = string.Format("SELECT * FROM [dbo].[Users] WHERE UserName='{0}'", userName);
            using (SqlConnection sqlConn = DatabaseHelper.GetConnection())
            {
                var reader = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, queryString);

                while (reader.Read())
                {
                    return User.From(reader);
                }
            }

            return null;
        }

        public IList<User> SearchUsersByText(string text)
        {
            var userList = new List<User>();
            var queryString = string.Format("SELECT * FROM [dbo].[Users] WHERE UserName LIKE '%{0}%'", text);
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

        private void ValidateUserExist(string userName)
        {
            var temp = GetUserByName(userName);
            if (temp != null)
            {
                throw new Exception("User Name already exist in the system.");
            }
        }
    }
}
