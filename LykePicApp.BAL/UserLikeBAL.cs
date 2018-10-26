using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserLikeBAL : BaseBAL
    {
        public UserLikeBAL Like(UserLike userLike)
        {
            //TODO

            return this;
        }

        public UserLikeBAL UnLike(Guid userId, Guid postId)
        {
            //TODO

            return this;
        }

        private UserLike GetUserLike(Guid userId, Guid postId)
        {
            //TODO
            return new UserLike();
        }
    }
}
