namespace Andreys.App.Controllers
{
    using Andreys.Data;
    using Andreys.Services;
    using Andreys.ViewModels.Home;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new ItemsCollectionViewModel
                {
                    Items = this.usersService.GetAllItems(this.User)
                };

                return this.View(viewModel,"Home");
            }

            return this.View();
        }
    }
}
