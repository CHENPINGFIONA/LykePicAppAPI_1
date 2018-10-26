using LykePicApp.DAL;
using LykePicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserPostBAL : BaseBAL
    {
        public void Save(UserPost userPost)
        {
            //TODO 
        }

        public void Delete(Guid postId)
        {
            //TODO 
        }

        public IList<UserPost> GetUserPosts(Guid userId)
        {
            //TODO 

            return new List<UserPost>();
        }

        private UserPost GetUserPost(Guid postId)
        {
            //TODO 

            return new UserPost();
        }
    }
}
