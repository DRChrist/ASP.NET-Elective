using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApplication.Models.Entities;


namespace StudentApplication.Models.Repositories
{
    public interface ICourseRepository
    {
         //Basic CRUD operation
        IEnumerable<Course> getAll();

        Course Get(int id);

        void Delete(Course course);

        void Update(Course course);

        void Save(Course course);
    }
}
