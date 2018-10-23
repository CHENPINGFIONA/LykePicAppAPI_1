using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LykePicApp.API.Models
{
    public class UserFollower
    {
        public Guid UserId { get; set; }

        public Guid FollowerUserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}