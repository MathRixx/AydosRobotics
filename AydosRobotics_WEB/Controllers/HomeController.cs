using System.Diagnostics;
using AydosRobotics_WEB.Context;
using AydosRobotics_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AydosRobotics_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
