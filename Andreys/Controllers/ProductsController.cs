using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
        
        [HttpPost]
        public HttpResponse Add(ProductsInputModel input)
        {
         
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(input.Name.Length <4 || input.Name.Length > 20)
            {
                return this.Error("The name of the product must be between 4 and 20 characters!");
            }

            if(input.Description.Length > 10)
            {
                return this.Error("Description is too long!");
            }

            var userId = this.User;

            this.productsService.CreatProduct(userId, input.Name, input.Description, input.ImageUrl, input.Category, input.Gender, input.Price);

            return this.Redirect("/");
        }
        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.productsService.IsThereSuchItem(id))
            {
                return this.Error("Sorry! Something went wrongm no such item!");
            }

            var viewModel = this.productsService.GetItem(id);
            return this.View(viewModel,"Details");
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.productsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
