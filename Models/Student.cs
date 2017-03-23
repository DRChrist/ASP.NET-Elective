using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StudentApplication.Models
{
    public class Student
    {
        //POCO Class - Plain Old CLR Object
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public int Age { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}