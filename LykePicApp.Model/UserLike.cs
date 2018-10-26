using System;

namespace LykePicApp.Model
{
    public class UserLike
    {
        public Guid LikeId { get; set; }

        public Guid UserId { get; set; }

        public Guid PostId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}