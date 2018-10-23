using LykePicApp.API.Models;
using System;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            return Ok<string>("");
        }

        [HttpPost]
        public IHttpActionResult Follow(Guid userId)
        {
            return Ok<string>("");
        }

        [HttpPost]
        public IHttpActionResult UnFollow(Guid userId)
        {
            return Ok<string>("");
        }

        [HttpGet]
        public IHttpActionResult GetUserInfo()
        {
            var user = new User()
            {
            };

            return Ok<User>(user);
        }
    }
}
