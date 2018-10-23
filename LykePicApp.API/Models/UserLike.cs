using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LykePicApp.API.Models
{
    public class UserLike
    {
        public Guid LikeId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}