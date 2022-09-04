using Mail_gönderme.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mail_gönderme.Controllers
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
        [HttpPost]
        public IActionResult Index(Email model,IFormFile fileToAttach)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add("alıcı-mail adresi0@gmail.com");            
            mailim.From = new MailAddress("gönderici-mail-adresi@gmail.com");
            mailim.Subject ="Mail konusu";

            string strmail = @"<html>
    html body          
                          </html> ";
            
            mailim.Body = string.Format(strmail, model.icerik,model.baslik);
            mailim.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("gönderici-mail-adresi@gmail.com", "uygulama yada mail şifresi")
            };
            mailim.Attachments.Add(new Attachment(fileToAttach.OpenReadStream(), fileToAttach.FileName));
            /*new SmtpClient();
            DeliveryMethod = SmtpDeliveryMethod.Network;
            UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("SOCStajyer@gmail.com", "Vakifbank.2022");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true; */
            try
            {
                smtp.Send(mailim);
                TempData["Message"] = "Mail Gönderildi.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Mail Gönderilemedi." + ex;

            }
            
          


            return RedirectToAction("Sonuc");
        }
        public IActionResult Sonuc()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
