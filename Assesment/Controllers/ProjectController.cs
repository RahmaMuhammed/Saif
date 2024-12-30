using Assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entites;

namespace Assesment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext db;

        public ProjectController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetProjects()
        {
            var l = await db.projects.ToListAsync();
            return View(l);
        }
        [HttpGet]
        public async Task<IActionResult> AddProject()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddProject(Project project)
        {
            await db.projects.AddAsync(project);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProjects");
        }

        public async Task<IActionResult> RemoveProject(int id)
        {
            var s = await db.projects.FirstOrDefaultAsync(x => x.ProjectID == id);
            db.projects.Remove(s);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProjects");
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            var s = await GetProjectByID(id);
            return View(s);


        }
        [HttpPost]
        public async Task<IActionResult> EditProject(Project project)
        {

            db.projects.Update(project);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProjects");

        }

        [HttpGet]

        public async Task<IActionResult> ProjectDetails(int id , Project project)
        {
            var l = await db.projects.Include(x => x.Tasks).ThenInclude(x => x.TeamMember).FirstOrDefaultAsync(x => x.ProjectID == id);
            return View(l);
        }


        public async Task<Project> GetProjectByID(int id)
        {
            var l = await db.projects.FirstOrDefaultAsync(x => x.ProjectID == id);
            return l;
        }


    }
}
