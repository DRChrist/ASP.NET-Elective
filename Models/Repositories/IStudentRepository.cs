using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApplication.Models.Entities;

namespace StudentApplication.Models.Repositories
{
    public interface IStudentRepository
    {
        //Basic CRUD operation
        IEnumerable<Student> getAll();

        Student Get(int id);

        void Delete(Student student);

        void Update(Student student);

        void Save(Student student);
    }
}
