using Scool_web_app.Models;
using System.ComponentModel.DataAnnotations;

namespace MySchoolApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public int DepartmentId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public List<StuCrsRes> StuCrsRes { get; set; }
    }
}