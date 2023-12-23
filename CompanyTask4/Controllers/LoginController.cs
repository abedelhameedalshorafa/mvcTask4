using CompanyTask4.Context;
using CompanyTask4.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompanyTask4.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationContext _context;

        public LoginController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Index_Post([Bind("Email","Password")] User user )
        {
            var users = _context.users.ToList();
            foreach (var u in users)
            {
                if (u.Email == user.Email && u.Password == user.Password)
                {
                    string userJson = JsonConvert.SerializeObject(u);
                    HttpContext.Session.SetString("LiveUser", userJson);
                    if (u.Role == Role.Manager)
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    else if (u.Role == Role.Employee)
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }
            }
            
            return View();
        }
    }
}
