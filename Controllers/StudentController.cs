using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Data;
using StudentApplication.Models.Repositories;
using StudentApplication.Models.Entities;
using StudentApplication.Models.ViewModels;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        //private readonly SchoolContext _context;
        
        //tightly coupled:
        //SchoolContext db = new SchoolContext();

        //loosely coupled:
        private IStudentRepository studentRepository;
        private ICourseRepository courseRepository;
        private IEnrollmentRepository enrollmentRepository;

        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            this.enrollmentRepository = enrollmentRepository;
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

        [HttpGet]
        public IActionResult Course(int id)
        {
            StudentCourseViewModel stcvm = new StudentCourseViewModel();
            stcvm.Student = studentRepository.Get(id);
            stcvm.Courses = courseRepository.getAll();

            return View(stcvm);
        }
        [HttpPost]
        public IActionResult Course(Enrollment enrollment)
        {
            if(ModelState.IsValid)
            {
                enrollmentRepository.Save(enrollment);
                return RedirectToAction("Index");
            }
            return View(enrollment.StudentID);
        }
       
        [HttpGet]
        public IActionResult Enrollments(int id)
        {
            Student st = studentRepository.Get(id);
            return View(st);
        }
        [HttpPost]
        public IActionResult Enrollments(Student st)
        {
            if(ModelState.IsValid)
            {
                foreach(var e in st.Enrollments)
                {
                    enrollmentRepository.Update(e);
                }
                return RedirectToAction("Index");
            }
            return View(st);
        }
    }

}
