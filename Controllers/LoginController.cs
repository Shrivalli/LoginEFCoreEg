using EFcoreEg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EFcoreEg.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession session;
        private readonly FisbankDbContext _db;
        public LoginController(FisbankDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usertbl t)
        {
            _db.Usertbls.Add(t);
            _db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usertbl t)
        {
            //Query Syntax
            //var result = (from i in _db.Usertbls
            //              where i.Email == t.Email && i.Password == t.Password
            //              select i).SingleOrDefault();

            //Method Syntax
            var result = _db.Usertbls.Where(x => x.Email == t.Email && x.Password == t.Password)
                .Select(x=>x).SingleOrDefault();
            if(result!=null)
            {
                HttpContext.Session.SetString("Uname", result.Username.ToString());
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
