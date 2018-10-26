using LykePicApp.Model;
using System;

namespace LykePicApp.BAL
{
    public class UserBAL : BaseBAL
    {
        public UserBAL Save(User user)
        {
            //TODO
            var queryString = "INSERT";

            if (user.UserId.Equals(Guid.Empty))
            {
                DAL.DAL.Create(queryString);
            }
            else
            {
                DAL.DAL.Update(queryString);
            }

            return this;
        }

        public User GetUserById(Guid userId)
        {
            //TODO
            return new User();
        }

        public User GetUserByName(string userName)
        {
            //TODO

            return new User();
        }
    }
}
