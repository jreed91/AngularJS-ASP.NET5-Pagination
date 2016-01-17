using Microsoft.AspNet.Mvc;

namespace angularjs_aspnet_paginate.Controllers
{
    public class HomeController : Controller {
         
         public IActionResult Index()
           {
                return View();
           }
    }
}