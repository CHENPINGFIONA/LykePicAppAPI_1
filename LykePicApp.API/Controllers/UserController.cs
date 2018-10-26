using LykePicApp.BAL;
using LykePicApp.Model;
using System;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            using (var bal = new UserBAL())
            {
                bal.Save(user);

                return Ok("Data Successful Saved");
            }
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUserInfo(Guid userId)
        {
            using (var bal = new UserBAL())
            {
                return Ok(bal.GetUserById(userId));
            }
        }

        [HttpGet]
        public IHttpActionResult Follow(Guid userId, Guid followerUserId)
        {
            using (var bal = new UserFollowerBAL())
            {
                var userFollower = new UserFollower()
                {
                    UserId = userId,
                    FollowerUserId = followerUserId,
                    CreatedDate = DateTime.Now
                };

                bal.Follow(userFollower);
                return Ok("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult UnFollow(Guid userId, Guid followerUserId)
        {
            using (var bal = new UserFollowerBAL())
            {
                bal.UnFollow(userId, followerUserId);

                return Ok("Data Successful Deleted");
            }
        }
    }
}
