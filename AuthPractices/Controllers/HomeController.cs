using AuthPractices.Models;
using Microsoft.AspNetCore.Http; //for SessionExtensions
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AuthPractices.Controllers
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
            SetCookie("kisi", "ali");
            ViewBag.kisi = GetCookie("kisi");

            SetSession("isim", "veli");
            ViewBag.isim = GetSession("isim");

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

        public void SetCookie(string key, string value)
        {
            HttpContext.Response.Cookies.Append(key, value);
        }
        public string GetCookie(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value); //bu cookie de değer var ise value'ya bas yoksa out dön
            return value;
        }
        public void SetSession(string key, string value)
        {
            //SessionExtensions sessionExtensions
            HttpContext.Session.SetString(key, value);
        }
        public string GetSession(string key)
        {
            return HttpContext.Session.GetString(key);
        }

    }
}
