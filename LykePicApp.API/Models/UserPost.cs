using System;

namespace LykePicApp.API.Models
{
    public class UserPost
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}