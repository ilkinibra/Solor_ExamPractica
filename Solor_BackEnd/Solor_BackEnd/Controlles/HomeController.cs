using Microsoft.AspNetCore.Mvc;
using Solor_BackEnd.DAL;
using Solor_BackEnd.Models;
using Solor_BackEnd.View_Models;
using System.Collections.Generic;
using System.Linq;

namespace Solor_BackEnd.Controlles
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = _context.Sliders.ToList();
            homeVM.About = _context.Abouts.FirstOrDefault();
            homeVM.Services = _context.Services.ToList();
            homeVM.Teams= _context.Teams.ToList();  
            return View(homeVM);
        }
    }
}
