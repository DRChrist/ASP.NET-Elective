using System;

namespace StudentApplication.Models
{
    public class Student
    {
        //POCO Class - Plain Old CLR Object
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Student(string firstName, string lastName, DateTime enrollmentDate)
        {
            FirstName = firstName;
            LastName = lastName;
            EnrollmentDate = enrollmentDate;
        }
    }
}