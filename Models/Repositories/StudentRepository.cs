using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Data;
using StudentApplication.Models.Entities;

namespace StudentApplication.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolContext _db;

        private DbSet<Student> _students;

        public StudentRepository(SchoolContext db)
        {
            _db = db;
            _students = db.Students;
        }
        void IStudentRepository.Delete(Student student)
        {
            _db.Students.Remove(student);
            _db.SaveChanges();
        }

        Student IStudentRepository.Get(int id)
        {
            Student st = _db.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).Where(r => r.StudentID == id).FirstOrDefault();
            return st;
        }

        IEnumerable<Student> IStudentRepository.getAll()
        {
            return _students;
        }

        void IStudentRepository.Save(Student student)
        {
            _db.Add(student);
            _db.SaveChanges();
        }

        void IStudentRepository.Update(Student student)
        {
            _db.Update(student);
            _db.SaveChanges();
        }
    }
}