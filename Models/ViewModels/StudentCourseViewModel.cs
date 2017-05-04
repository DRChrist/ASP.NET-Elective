using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using StudentApplication.Models.Entities;

namespace StudentApplication.Models.ViewModels
{
    public class StudentCourseViewModel
    {
       public Student Student { get; set; }
       public IEnumerable<Course> Courses { get; set; }

    }
}