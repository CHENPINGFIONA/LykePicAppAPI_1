﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LykePicApp.API.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}