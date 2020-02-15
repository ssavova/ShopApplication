﻿using Andreys.Services;
using Andreys.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    public class UsersController :Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UsersInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if(userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);
            return this.Redirect("/");
            
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UsersRegisterInputModel input)
        {
            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            if (input.Username?.Length < 4 || input.Username?.Length > 10)
            {
                return this.Error("Username should be between 4 and 10 characters .");
            }

            if (input.Password?.Length < 6 || input.Password?.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters.");
            }

            if (!this.usersService.IsEmailValid(input.Email))
            {
                return this.Error("Invalid email!");
            }

            if (this.usersService.IsUsernameUsed(input.Username))
            {
                return this.Error("Username already used!");
            }

            if (this.usersService.IsEmailUsed(input.Email))
            {
                return this.Error("Email already used!");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            SignOut();
            return this.Redirect("/");
        }
    }
}
