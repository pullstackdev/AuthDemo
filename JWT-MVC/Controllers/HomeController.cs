using JWT_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_MVC.Controllers
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
            // a sample jwt encoded token string which is supposed to be extracted from 'Authorization' HTTP header in your Web Api controller
            var tokenString = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjpbIjdmN2UwZTVmLTUyMmMtNGVlYy05MTFkLTFmOGEzZTU0OTM0ZiIsImFkbWluIl0sImV4cCI6MTYyMjQ0OTI4NiwiaXNzIjoiVG9rZW5BdXRoRGVtbyIsImF1ZCI6IlRva2VuQXV0aERlbW8ifQ.vAZZff3yEoNz78lguxr3AlelevwjQyqr4l-jBLj_NsU";
            var jwtEncodedString = tokenString.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            Console.WriteLine("email => " + token.Claims.First(c => c.Type == "Name").Value);

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
