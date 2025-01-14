﻿

namespace SMS.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Contracts;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        public HomeController(Request request,IUserService userService,IProductService productService)
            : base(request)
        {
            this.productService = productService;
            this.userService = userService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                string userName = userService.GetUserName(this.User.Id);

                var model = new
                {
                    Username = userName,
                    IsAuthenticated=true,
                    Products =productService.GetProducts()
                };

                return View(model, "/Home/IndexLoggedIn");
            }



            return this.View(
                new
            {
                IsAuthenticated = false
            });
        }
    }
}