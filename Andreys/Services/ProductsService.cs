using Andreys.Data;
using Andreys.Enumerations;
using Andreys.Models;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService:IProductsService
    {
        private readonly AndreysDbContext db;
        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

      
        public void CreatProduct(string userId, string name, string desc, string imgUrl, string category, string gender, decimal price)
        {
            Category categoryEnum = (Category)Enum.Parse(typeof(Category), category);
            Gender genderEnum = (Gender)Enum.Parse(typeof(Gender), gender);

            Product product = new Product()
            {
                Name = name,
                Description = desc,
                ImageUrl = imgUrl,
                Category = categoryEnum,
                Gender = genderEnum,
                Price = price,
                UserId = userId,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }


        public bool IsThereSuchItem(int id)
        {
            return this.db.Products.Any(i => i.Id == id);
        }

        public ItemDetaisViewModel GetItem(int id)
        {
            var searchedItem = this.db.Products.Where(i => i.Id == id).FirstOrDefault();
           
            var genderEnum = Enum.GetName(typeof(Gender), searchedItem.Gender);
            var categoryEnum = Enum.GetName(typeof(Category), searchedItem.Category);

            var viewModel = new ItemDetaisViewModel
            {
                Id = searchedItem.Id,
                Name = searchedItem.Name,
                Price = searchedItem.Price,
                Description = searchedItem.Description,
                ImageUrl = searchedItem.ImageUrl,
                Category = categoryEnum,
                Gender = genderEnum,
            };

            return viewModel;
        }

        public void Delete(int id)
        {
            var searcheditem = this.db.Products.FirstOrDefault(p => p.Id == id);
            this.db.Products.Remove(searcheditem);
            this.db.SaveChanges();
        }
    }
}
