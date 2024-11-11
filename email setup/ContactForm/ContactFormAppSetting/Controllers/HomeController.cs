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
            try
            {
                //var data = new { Name, Email, Message };

                //Retrieving email settings from appsettings.json.
                // SmtpServer = configuration.GetValue<string>("EmailSettings:SmtpServer")
                var smtpServer = configuration["EmailSettings:SmtpServer"]; // return string
                var smtpPort = configuration.GetValue<int>("EmailSettings:SmtpPort");
                var senderEmail = configuration["EmailSettings:SenderEmail"];
                var senderPass = configuration.GetValue<string>("EmailSettings:SenderPassword");
                var enableSSL = configuration.GetValue<bool>("EmailSettings:EnableSSL");

                //setup SMTP client for sending email
                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, senderPass),
                    EnableSsl = enableSSL

                };
                // create email messae
                var mailMessage = new MailMessage()
                {
                    From = new MailAddress("Servicedoon@gmail.com"),
                    Subject = "New Form Enquiry",
                    Body = $"Name : {Name}\n Email : {Email}\n Message :{Message}",
                    IsBodyHtml = false,
                };
                // Add recipient email 
                mailMessage.To.Add("nazim142322@gmail.com");

                //Send email
                await smtpClient.SendMailAsync(mailMessage);
                TempData["EmailSuccess"] = "Message Sent";
            }
            catch (Exception ex)
            {
                TempData["EmailError"] = "There was an error sending the message"+ex.Message;
            }

            return RedirectToAction("Index");
            //return Json(new {Name, Email, Message, smtpServer, smtpPort, senderEmail, senderPass, enableSSL});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}


