using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Data;
using StudentApplication.Models.Entities;


namespace StudentApplication.Models.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private SchoolContext _db;

        private DbSet<Enrollment> _enrollments;

        public EnrollmentRepository(SchoolContext db)
        {
            _db = db;
            _enrollments = db.Enrollments;
        }
        public void Delete(Enrollment enrollment)
        {
            _db.Enrollments.Remove(enrollment);
            _db.SaveChanges();
        }

        public Enrollment Get(int id)
        {
            Enrollment e = _db.Enrollments.Find(id);
            return e;
        }

        public IEnumerable<Enrollment> getAll()
        {
            return _enrollments;
        }

        public void Save(Enrollment enrollment)
        {
            _db.Add(enrollment);
            _db.SaveChanges();
        }

        public void Update(Enrollment enrollment)
        {
            _db.Update(enrollment);
            _db.SaveChanges();
        }
    }
}