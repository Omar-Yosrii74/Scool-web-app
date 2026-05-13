namespace MySchoolApp.ViewModels
{
    public class DepartmentViewModel
    {
        public string DepartmentName { get; set; }
        public List<string> StudentsOver25 { get; set; }
        public string DepartmentState { get; set; }  // "Main" or "Branch"
    }
}