using System.ComponentModel.DataAnnotations;

namespace MySchoolApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
        public Department Department { get; set; }
    }
}