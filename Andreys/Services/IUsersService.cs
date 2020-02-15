using Andreys.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);
        string GetUserId(string username, string password);

        bool IsUsernameUsed(string username);

        bool IsEmailUsed(string email);

        bool IsEmailValid(string email);

        ICollection<ItemsDetailsHomeViewModel> GetAllItems(string userId);
    }
}
