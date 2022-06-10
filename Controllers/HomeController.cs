using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testaundit.Models;
using testaundit.Data;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace testaundit.Controllers
{
    public class HomeController : Controller
    {
        private testaunditContext _context;
        private readonly ILogger<HomeController> _logger;

/*        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public HomeController(testaunditContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index(string id,string Name )
        {
            var blog = _context.blog.ToList();
            Console.WriteLine(Name);
            return View(blog);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}