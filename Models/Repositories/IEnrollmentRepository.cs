using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApplication.Models;
using StudentApplication.Models.Entities;


namespace StudentApplication.Models.Repositories
{
    public interface IEnrollmentRepository
    {
        //Basic CRUD operation
        IEnumerable<Enrollment> getAll();

        Enrollment Get(int id);

        void Delete(Enrollment enrollment);

        void Update(Enrollment enrollment);

        void Save(Enrollment enrollment);
    }
}
