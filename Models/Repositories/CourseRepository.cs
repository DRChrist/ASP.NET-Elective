using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Data;
using StudentApplication.Models.Entities;

namespace StudentApplication.Models.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private SchoolContext _db;

        private DbSet<Course> _courses;

        public CourseRepository(SchoolContext db)
        {
            _db = db;
            _courses = db.Courses;
        }

        void ICourseRepository.Delete(Course course)
        {
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        Course ICourseRepository.Get(int id)
        {
            Course c = _db.Courses.Find(id);
            return c;
        }

        IEnumerable<Course> ICourseRepository.getAll()
        {
            return _courses;
        }

        void ICourseRepository.Save(Course course)
        {
            _db.Add(course);
            _db.SaveChanges();
        }

        void ICourseRepository.Update(Course course)
        {
            _db.Update(course);
            _db.SaveChanges();
        }
    }
}