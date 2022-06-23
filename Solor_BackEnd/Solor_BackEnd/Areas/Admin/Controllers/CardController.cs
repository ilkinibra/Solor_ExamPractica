using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Solor_BackEnd.DAL;
using Solor_BackEnd.Helpers;
using Solor_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Solor_BackEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CardController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public CardController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env=env;
        }

        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.ToList();
            return View(teams);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Team dbTeam =await _context.Teams.FindAsync(id);
            if(dbTeam == null) return NotFound();
            return View(dbTeam);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Team dbTeam = await _context.Teams.FindAsync(id);
            if (dbTeam == null) return NotFound();
            Helper.DeleteFile(_env, "img",dbTeam.ImageUrl);
            _context.Teams.Remove(dbTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(Team team)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!team.Photo.ContentType.Contains("image/"))
            {
                return View();
            }
            if(team.Photo.Length/1024>1000)
            {
                return View();
            }
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + team.Photo.FileName;
            string result = Path.Combine(path, "img", fileName);

            using(FileStream stream=new FileStream(result, FileMode.Create))
            {
                await team.Photo.CopyToAsync(stream);
            };
            Team newTeam = new Team();
            newTeam.ImageUrl = fileName;
            await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
