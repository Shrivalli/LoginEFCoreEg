using Microsoft.AspNetCore.Mvc;
using EFcoreEg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFcoreEg.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly FisbankDbContext db;
        public EmployeeController(FisbankDbContext db) //Dependency Injection
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Uname");
            if (ViewBag.Username != null)
            {
                var result = db.Employees.Include(x => x.Dept);
                return View(result.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult AddEmployee()
        {

            //var result = db.Departments.ToList();
            ViewBag.Deptid = new SelectList(db.Departments, "Did", "Dname");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee employee = db.Employees.Find(id);
            //var result = db.Departments.ToList();
            ViewBag.Deptid = new SelectList(db.Departments, "Did", "Dname");
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            db.Employees.Update(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
