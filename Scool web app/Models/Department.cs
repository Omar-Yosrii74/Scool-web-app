using Scool_web_app.Models;
using System.ComponentModel.DataAnnotations;

namespace MySchoolApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string MgrName { get; set; }

        // Navigation Properties
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}