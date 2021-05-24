using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace coreIdentity.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string text)
        {
            List<string> list = new List<string>
            {
                "1","2"
            };

            if (list.Contains(text)) //kullanıcı kayıtlı ise
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, text) //Claim burada type ve value alacak, claim'e bu user'ı atadık
                };
                var userIdentity = new ClaimsIdentity(claims, "Login"); //claim'i ve type'ı istedi
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal); //şifreli bir cookie oluşturur
                return RedirectToAction("Index", "Home"); //giriş yapabileni category'e gönder
            }
            return View(); //kayıtlı olmayan user tekrar burada
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); //girerken oluşturulan şifreli cookie'yi signout yapıyoruz
            return RedirectToAction("Index", "Login");
        }
    }
}
