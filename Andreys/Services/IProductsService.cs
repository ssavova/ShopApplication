using Andreys.Data;
using Andreys.Enumerations;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void CreatProduct(string userId, string name, string desc, string imgUrl, string category, string gender, decimal price);

        ItemDetaisViewModel GetItem(int id);

        void Delete(int id);

        bool IsThereSuchItem(int id);
    }
}
