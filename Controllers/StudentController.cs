using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Data;
using StudentApplication.Models.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        //private readonly SchoolContext _context;
        
        //tightly coupled:
        //SchoolContext db = new SchoolContext();

        //loosely coupled:
        private IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Student> students = studentRepository.getAll();
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
                studentRepository.Save(st);
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
            Student st = studentRepository.Get(id);
            return View(st);
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student st)
        {
            studentRepository.Delete(st);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Student st = studentRepository.Get(id);
            return View(st);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student student = studentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student st)
        {
            if(ModelState.IsValid)
            {
                studentRepository.Update(st);
                return RedirectToAction("Index");
            }
            return View(st);
        } 
    }

}
