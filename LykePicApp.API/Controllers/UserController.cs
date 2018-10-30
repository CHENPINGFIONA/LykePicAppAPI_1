using LykePicApp.BAL;
using LykePicApp.DAL;
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
        public IHttpActionResult Login(string userName, string password)
        {
            using (var bal = new UserBAL())
            {
                var user = bal.Login(userName, password);

                return Ok(user);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            using (var bal = new UserBAL())
            {
                user.CreatedDate = DateTime.Now;
                bal.Save(user);

                return Ok("Data Successful Saved");
            }
        }

        [HttpGet]
        public IHttpActionResult GetUser(Guid userId)
        {
            using (var bal = new UserBAL())
            {
                var user = bal.GetUserById(userId);
                return Ok(user);
            }
        }

        [HttpGet]
        public IHttpActionResult SearchUsersByText(string text)
        {
            using (var bal = new UserBAL())
            {
                var userList = bal.SearchUsersByText(text);
                return Ok(userList);
            }
        }

        [HttpGet]
        public IHttpActionResult Follow(Guid userId, Guid followerUserId)
        {
            using (var bal = new UserFollowerBAL())
            {
                bal.Follow(userId, followerUserId);
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

        [HttpGet]
        public IHttpActionResult GetFollowerList(Guid userId)
        {
            using (var bal = new UserFollowerBAL())
            {
                var followerList = bal.GetFollowUserList(userId);
                return Ok(followerList);
            }
        }
    }
}
