namespace MySchoolApp.Models
{
    public class StuCrsRes
    {
        // Composite Primary Key (هيتحدد في DbContext)
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public int Grade { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}