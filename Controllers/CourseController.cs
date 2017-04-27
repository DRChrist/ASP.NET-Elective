using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Models.Repositories;

namespace StudentApplication.Controllers
{
    class CourseController : Controller
    {
        
        private ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Course> courses = courseRepository.getAll();
            return View(courses);
        }
    }
}