using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationDepenInje.Models;
using WebApplicationDepenInje.Services;

namespace WebApplicationDepenInje.Controllers
{
    public class HomeController : Controller
    {
        // Private readonly field to hold the injected service instance
        // Step 1: Declare a field to hold the instance of MyService
        private readonly MyService myservice;

        // Constructor that accepts `MyService` as a parameter
        // Dependency injection automatically provides an instance of `MyService` here
        public HomeController(MyService myservice)
        {
            this.myservice = myservice;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["greeting"] = await myservice.myHelloasync("Nazim");
            return View();
        }        
    }
}

