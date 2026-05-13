using Scool_web_app.Models;
using System.ComponentModel.DataAnnotations;

namespace MySchoolApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<StuCrsRes> StuCrsRes { get; set; }
    }
}