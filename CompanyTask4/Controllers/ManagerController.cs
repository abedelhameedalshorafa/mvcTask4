using CompanyTask4.Context;
using CompanyTask4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace CompanyTask4.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationContext _context;

        public ManagerController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display()
        {
            return View(_context.users.Where(user => user.Role == Role.Employee).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.departments = _context.departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,FirstName,LastName,BirthDate,PhoneNumber,NationalID,Nationality,MartialStatus,HireDate,Password,DepartmentID")] User user)
        {
            user.Role = Role.Employee;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Display));
            return View(user);
        }

        public IActionResult Search(string searchTerm)
        {
            var users = _context.users.ToList();
            var results = new List<User>();
            foreach(var user in users)
            {
                if(user.FirstName.ToUpper()==searchTerm.ToUpper()|| user.LastName.ToUpper()==searchTerm.ToUpper())
                {
                    results.Add(user);
                }
            }
            return View("Display", results);
        }



    }
}
