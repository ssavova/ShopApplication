﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.ViewModels.Users
{
    public class UsersRegisterInputModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
