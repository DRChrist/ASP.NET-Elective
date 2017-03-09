using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC
{
    public class StudentController : Controller
    {
        MyDbContext db = new MyDbContext();

        public void createStudent(string firstName, string lastName, DateTime enrollmentDate)
        {
            Student st = new Student(firstName, lastName, enrollmentDate);
            db.Students.Add(st);
            db.SaveChanges();
        }

        public void updateStudent

        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }
    }
}
