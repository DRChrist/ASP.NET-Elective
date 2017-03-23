using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        MyDbContext db = new MyDbContext();

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = db.Students.ToList();
            return View(students);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("StudentID,FirstName,LastName,EnrollmentDate")] Student st)
        {
            if(ModelState.IsValid)
            {
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }

}
