using Microsoft.AspNetCore.Mvc;
using ContactForm.ViewModel;
using System.Net.Mail;
using System.Net;
using System.Reflection;

namespace ContactForm.Controllers
{
    public class HomeController : Controller
    {              
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactFormViewModel model)
        {
            try
            {
                //setup SMTP client for sending email
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,// SMTP port for Gmail
                    Credentials = new NetworkCredential("servicedoon@gmail.com", "gzbgaiwolivxfazy"), // Gmail account credentials
                    EnableSsl = true // Enable SSL for security
                };

                //creat the email message
                var mailMessage = new MailMessage()
                {
                    From = new MailAddress("servicedoon@gmail.com"),// Sender's email
                    Subject = "New Form inquiry",
                    //Body = $"Name = {model.Name}\n Email : {model.Email}\nMessage: {model.Message}",
                    //IsBodyHtml = false,
                   IsBodyHtml = true // Set to true to enable HTML content
                };

                // Set the Reply-To address
                //mailMessage.ReplyToList.Add(new MailAddress(model.Email)); // Adds the sender's email as the Reply-To
                mailMessage.ReplyToList.Add(new MailAddress("khan.nazim200@gmail.com"));

                // Define the HTML content
                mailMessage.Body = @"
                                    <html>
                                    <head>
                                        <style>
                                            body { font-family: Arial, sans-serif; }
                                            h2 { color: #333; }
                                            p { margin: 5px 0; }
                                            .highlight { color: #0066cc; }
                                        </style>
                                    </head>
                                    <body>
                                        <h2>New Contact Form Submission</h2>
                                        <p><strong>Name:</strong> <span class='highlight'>" + model.Name + @"</span></p>
                                        <p><strong>Email:</strong> <span class='highlight'>" + model.Email + @"</span></p>
                                        <p><strong>Message:</strong></p>
                                        <p>" + model.Message + @"</p>
                                    </body>
                                    </html>";

                // Add recipient email (where you want to receive the contact form details)
                mailMessage.To.Add("nazim142322@gmail.com");

                //send the email
                //smtpClient.Send(mailMessage);
                await smtpClient.SendMailAsync(mailMessage);
                TempData["EmailSuccess"] = "Message Sent";
            }
            catch(Exception ex)
            {
                // Display an error message if email sending fails
                TempData["EmailError"] = "There was an error sending your message: " + ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}

