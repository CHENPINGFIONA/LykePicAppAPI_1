using LykePicApp.Model;
using System;

namespace LykePicApp.BAL
{
    public class UserBAL : BaseBAL
    {
        public UserBAL Save(User user)
        {
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
    }
}
