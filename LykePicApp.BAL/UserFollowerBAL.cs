using LykePicApp.Model;
using System;

namespace LykePicApp.BAL
{
    public class UserFollowerBAL : BaseBAL
    {
        public UserFollowerBAL Follow(UserFollower userFollower)
        {
            //TODO

            return this;
        }

        public UserFollowerBAL UnFollow(Guid userId, Guid followerUserId)
        {
            //TODO

            return this;
        }

        private UserFollower GetUserFollower(Guid userId, Guid followerUserId)
        {
            //TODO
            return new UserFollower();
        }
    }
}
