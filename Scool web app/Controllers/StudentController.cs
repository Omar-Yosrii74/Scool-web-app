using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Data;

namespace MySchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Student/ShowAll
        public IActionResult ShowAll()
        {
            var students = _context.Students
                                   .Include(s => s.Department)
                                   .ToList();
            return View(students);
        }

        // GET: /Student/ShowDetails?id=3
        public IActionResult ShowDetails(int id)
        {
            var student = _context.Students
                                  .Include(s => s.Department)
                                  .Include(s => s.StuCrsRes)
                                      .ThenInclude(sc => sc.Course)
                                  .FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}