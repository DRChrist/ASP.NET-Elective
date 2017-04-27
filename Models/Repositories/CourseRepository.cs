using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Data;

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

        public void Delete(Course course)
        {
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        public Course Get(int id)
        {
            Course c = _db.Courses.Find(id);
            return c;
        }

        public IEnumerable<Course> getAll()
        {
            return _courses;
        }

        public void Save(Course course)
        {
            _db.Add(course);
            _db.SaveChanges();
        }

        public void Update(Course course)
        {
            _db.Update(course);
            _db.SaveChanges();
        }
    }
}