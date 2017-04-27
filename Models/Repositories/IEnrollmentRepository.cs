using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApplication.Models;

namespace StudentApplication.Models.Repositories
{
    interface IEnrollmentRepository
    {
        //Basic CRUD operation
        IEnumerable<Enrollment> getAll();

        Enrollment Get(int id);

        void Delete(Enrollment enrollment);

        void Update(Enrollment enrollment);

        void Save(Enrollment enrollment);
    }
}
