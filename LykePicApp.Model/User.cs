using System;

namespace LykePicApp.Model
{
    public class User
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}