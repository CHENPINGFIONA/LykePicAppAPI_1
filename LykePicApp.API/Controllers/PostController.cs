using LykePicApp.BAL;
using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class PostController : ApiController
    {
        [HttpPost]
        public IHttpActionResult UploadPost(UserPost post)
        {
            using (var bal = new UserPostBAL())
            {
                post.CreatedDate = DateTime.Now;
                bal.Save(post);

                return Ok("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult GetPostList(Guid userId)
        {
            using (var bal = new UserPostBAL())
            {
                var postList = bal.GetUserPosts(userId);
                return Ok(postList);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPost(Guid postId)
        {
            using (var bal = new UserPostBAL())
            {
                var post = bal.GetUserPost(postId);
                return Ok(post);
            }
        }

        [HttpGet]
        public IHttpActionResult LikePost(Guid userId, Guid postId)
        {
            using (var bal = new UserLikeBAL())
            {
                bal.Like(userId, postId);
                return Ok("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult DisLikePost(Guid userId, Guid postId)
        {
            using (var bal = new UserLikeBAL())
            {
                bal.DisLikePost(userId, postId);

                return Ok("Data Successful Deleted");
            }
        }
    }
}
