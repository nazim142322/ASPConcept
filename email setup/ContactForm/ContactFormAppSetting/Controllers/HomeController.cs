using ContactFormAppSetting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;
using ContactFormAppSetting.ViewModel;

namespace ContactFormAppSetting.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail(string Name, string Email, string Message)
        {

            //var data = new { Name, Email, Message };

            var smtpSetting = new EmailSettingsViewModel
            {
               // SmtpServer = configuration.GetValue<string>("EmailSettings:SmtpServer")
               SmtpServer = configuration["EmailSettings:SmtpServer"] // return string
            };
            return Json(smtpSetting);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}


