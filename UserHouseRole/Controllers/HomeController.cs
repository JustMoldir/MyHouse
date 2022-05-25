using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UserHouseRole.Models;

namespace UserHouseRole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
     
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(SendMailDto sendMailDto)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("zholdasova.moly@gmail.com");

                mail.To.Add("zholdasova.moly@gmail.com");


                mail.Subject = sendMailDto.Number;
                mail.Subject = sendMailDto.Email;

                mail.IsBodyHtml = true;
                string content = "Name : " + sendMailDto.Name;
                string content1 = "Number : " + sendMailDto.Number;
                string content2 = "Email : " + sendMailDto.Email;
                content += "<br/> Message : " + sendMailDto.Message + "<br/>  " + content1 + "<br/> " + content2;

                mail.Body = content;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");


                NetworkCredential networkCredential = new NetworkCredential("zholdasova.moly@gmail.com", "moldir!2001");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                ViewBag.Message = "Mail Send";
                ModelState.Clear();
            }

            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
    }
}
