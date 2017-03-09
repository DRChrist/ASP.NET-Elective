using System.Collections.Generic;
using StudentApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {
        
        MyDbContext db = new MyDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            db.Students.Add(new Student(){FirstName = "Claude",
             LastName = "Bovary",
             EnrollmentDate = new DateTime(1990,10,22)
             });

            db.SaveChanges();

            List<Student> students = db.Students.ToList();
            //students.Add(new Student("Mogens", 34));
            //students.Add(new Student("John", 33));
            //students.Add(new Student("Børge", 35));

            ViewBag.Y = students;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}