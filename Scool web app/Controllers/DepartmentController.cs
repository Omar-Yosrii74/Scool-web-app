using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Data;
using MySchoolApp.Models;
using MySchoolApp.ViewModels;

namespace MySchoolApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Department/ShowAll
        public IActionResult ShowAll()
        {
            var departments = _context.Departments
                                      .Include(d => d.Students)
                                      .ToList();
            return View(departments);
        }

        // GET: /Department/ShowDetails/1
        public IActionResult ShowDetails(int id)
        {
            var department = _context.Departments
                                     .Include(d => d.Students)
                                     .Include(d => d.Courses)
                                     .FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // GET: /Department/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Department/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(department);
        }

        // GET: /Department/DeptStats/1
        public IActionResult DeptStats(int id)
        {
            var department = _context.Departments
                                     .Include(d => d.Students)
                                     .FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound();

            var viewModel = new DepartmentViewModel
            {
                DepartmentName = department.Name,
                StudentsOver25 = department.Students
                                           .Where(s => s.Age > 25)
                                           .Select(s => s.Name)
                                           .ToList(),
                DepartmentState = department.Students.Count > 50 ? "Main" : "Branch"
            };

            return View(viewModel);
        }
    }
}