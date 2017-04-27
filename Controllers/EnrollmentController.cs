using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Models.Repositories;

namespace StudentApplication.Controllers
{
    class EnrollmentController : Controller
    {
        private IEnrollmentRepository enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public IActionResult Enrollments()
        {
            IEnumerable<Enrollment> enrollments = enrollmentRepository.getAll();
            return View(enrollments);
        }
    }
}