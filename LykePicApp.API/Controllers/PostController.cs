using LykePicApp.BAL;
using LykePicApp.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class PostController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(UserPost userPost)
        {
            using (var bal = new UserPostBAL())
            {
                bal.Save(userPost);

                return Ok("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult GetPostList(Guid userId)
        {
            using (var bal = new UserPostBAL())
            {
                return Ok(bal.GetUserPosts(userId));
            }
        }

        [HttpGet]
        public IHttpActionResult LikePost(Guid userId, Guid postId)
        {
            using (var bal = new UserLikeBAL())
            {
                var userLike = new UserLike()
                {
                    UserId = userId,
                    PostId = postId,
                    CreatedDate = DateTime.Now
                };

                bal.Like(userLike);
                return Ok("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult UnLike(Guid userId, Guid postId)
        {
            using (var bal = new UserLikeBAL())
            {
                bal.UnLike(userId, postId);

                return Ok("Data Successful Deleted");
            }
        }
    }
}
