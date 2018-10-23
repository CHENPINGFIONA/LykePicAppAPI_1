using LykePicApp.API.Models;
using System;
using System.Web.Http;

namespace LykePicApp.API.Controllers
{
    public class PostController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(UserPost userPost)
        {
            return Ok<string>("");
        }

        [HttpGet]
        public IHttpActionResult GetPostList(Guid userId)
        {
            return Ok<string>("");
        }
    }
}
