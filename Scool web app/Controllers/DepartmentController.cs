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
        public DepartmentController(AppDbContext context) { _context = context; }

        // /Department/ShowAll
        public IActionResult ShowAll()
        {
            var departments = _context.Departments
                                      .Include(d => d.Students)
                                      .ToList();
            return View(departments);
        }

        // /Department/ShowDetails?id=1
        public IActionResult ShowDetails(int id)
        {
            var dept = _context.Departments
                               .Include(d => d.Students)
                               .Include(d => d.Courses)
                               .FirstOrDefault(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        // GET: /Department/Add
        [HttpGet]
        public IActionResult Add() => View();

        // POST: /Department/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Department dept)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(dept);
        }

        // /Department/DeptStats?id=1
        public IActionResult DeptStats(int id)
        {
            var dept = _context.Departments
                               .Include(d => d.Students)
                               .FirstOrDefault(d => d.Id == id);
            if (dept == null) return NotFound();

            var vm = new DepartmentViewModel
            {
                DepartmentName = dept.Name,
                StudentsOver25 = dept.Students
                                     .Where(s => s.Age > 25)
                                     .Select(s => s.Name)
                                     .ToList(),
                DepartmentState = dept.Students.Count > 50 ? "Main" : "Branch"
            };
            return View(vm);
        }
    }
}