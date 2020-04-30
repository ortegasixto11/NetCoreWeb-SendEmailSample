using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmailSender;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendEmail_Web.Models;

namespace SendEmail_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailSender.EmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, EmailConfiguration emailConfig)
        {
            _logger = logger;
            _emailSender = new EmailSender.EmailSender(emailConfig);
        }

        public IActionResult Index()
        {
            try
            {
                var message = new EmailSender.Message(new string[] { "sixto_miguel@hotmail.com" }, "Test email", "This is the content from our email.");
                _emailSender.SendEmail(message);
            }
            catch (Exception ex)
            {
                int x = 12;
                throw;
            }
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
    }
}
