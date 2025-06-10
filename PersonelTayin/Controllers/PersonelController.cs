using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonelTayin.Data;
using PersonelTayin.Models;

namespace PersonelTayin.Controllers
{
    public class PersonelController : Controller
    {
           

            private readonly AppDbContext _context;

            public PersonelController(AppDbContext context)
            {
                _context = context;
            }

           


     
    

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");

        }



    }



    }

