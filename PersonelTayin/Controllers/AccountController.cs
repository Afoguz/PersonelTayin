using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelTayin.Data;
using PersonelTayin.Models;
using PersonelTayin.ViewsModels;
using System.Security.Claims;

namespace UsersApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Personeller = _context.UserAccounts.ToList(),

                Talepler = _context.Basvurular
                    .Include(b => b.AdliyeAdi)
                    .OrderByDescending(b => b.BasvuruTarihi)
                    .Take(10)
                    .ToList(),

                BasvuruYapanlar = _context.Basvurular
                    .Include(b => b.UserAccount)
                    .Include(b => b.AdliyeAdi)
                    .OrderByDescending(b => b.BasvuruTarihi)
                    .ToList()
            };

            return View(viewModel);
        }




        [HttpPost]
        public IActionResult Basvurular(string aciklama, string il, string tayinTuru)
        {
            ViewBag.aciklama = aciklama;
            ViewBag.il = il;
            ViewBag.tayinTuru = tayinTuru;
            return View("Basarili");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts.Where(x => x.UserName == model.Username && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Name", user.FullName),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Usarname Veya Şifre Hatalı");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }


        private readonly Admin sabitAdmin = new Admin(); // "admin" / "1920"

        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Admin(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.KullaniciAdi == sabitAdmin.KullaniciAdi && model.Sifre == sabitAdmin.Sifre)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, sabitAdmin.AdminAdi),
                new Claim("Name", sabitAdmin.KullaniciAdi),
                new Claim(ClaimTypes.Role, "Admin"),
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity)
                    );

                    TempData["Basari"] = $"HOSGELDİNİZ YÖNETİCİ, {sabitAdmin.AdminAdi}";
                    return RedirectToAction("Index");



                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            }

            return View(model);
        }



        [Authorize]
        public IActionResult Dashboard()
        {
            var email = User.Identity.Name;
            var user = _context.UserAccounts.FirstOrDefault(u => u.Email == email);
            if (user == null) return RedirectToAction("Login");

            var talepler = _context.Basvurular
                .Where(b => b.UserAccountId == user.Id)
                .OrderByDescending(b => b.BasvuruTarihi)
                .ToList();

            var adliyes = _context.Adliyes.ToList();

            var model = new DashboardViewModel
            {
                Personel = user,
                Talepler = talepler,
                Adliyes = adliyes
            };

            return View(model);
        }



        public IActionResult SifremiUnuttum()
        {
            return View();
        }




        public IActionResult Basarili()
        {
            return View();
        }






        [HttpGet]
        public IActionResult Form()
        {

            var adliyeler = _context.Adliyes
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AdliyeAdi
            }).ToList();

            ViewBag.AdliyeListesi = adliyeler;


            return View();
        }



        [HttpPost]
        public IActionResult Form(Basvuru basvuru)
        {
            if (!ModelState.IsValid)
            {
                return View(basvuru);
            }

            var currentUser = _context.UserAccounts.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (currentUser == null)
            {
                ModelState.AddModelError("", "Kullanıcı oturumu bulunamadı.");
                return View(basvuru);
            }

            var adliye = _context.Adliyes.FirstOrDefault(a => a.Id == basvuru.AdliyeAdiId);

            var yeniBasvuru = new Basvuru
            {
                UserAccountId = currentUser.Id,
                AdliyeAdiId = basvuru.AdliyeAdiId,
                BasvuruTuru = basvuru.BasvuruTuru,
                Aciklama = basvuru.Aciklama,
                BasvuruTarihi = DateTime.Now,
                AdliyeAdi = adliye
            };

            _context.Basvurular.Add(yeniBasvuru);
            _context.SaveChanges();


            var gonderilecekBasvuru = _context.Basvurular
                .Include(b => b.AdliyeAdi)
                .FirstOrDefault(b => b.Id == yeniBasvuru.Id);

            return View("Basarili", gonderilecekBasvuru);

        }


        //TempData["Basari"] = "Tayin başvurunuz başarıyla alınmıştır.";
        //return RedirectToAction("Dashboard");
    }



}








