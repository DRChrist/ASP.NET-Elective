using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }
        SchoolContext db = new SchoolContext();

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Courses()
        {
            List<Course> courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Enrollments()
        {
            List<Enrollment> enrollments = db.Enrollments.ToList();
            return View(enrollments);
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
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);

            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student st)
        {
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Student student = db.Students.Find(id);

            return View(student);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student student = db.Students.Find(id);
        }

        [HttpPost]
        public IActionResult Update(Student st)
        {
            
        }
    }

}
