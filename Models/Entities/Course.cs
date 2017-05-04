using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplication.Models.Entities
{
      public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
