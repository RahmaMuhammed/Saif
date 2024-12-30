using Assesment.Models;
using Assesment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entites;

namespace Assesment.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext db;

        public TasksController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var l = await db.tasks.FirstOrDefaultAsync(x => x.TasksID == id);
            var projects = await db.projects.ToListAsync();
            var members = await db.teamMembers.ToListAsync();

            TaskViewModel taskViewModel = new TaskViewModel()
            {
                teamMembers = members,
                projects = projects,
                Title = l.Title,
                Description = l.Description,
                Priority = l.Priority,
                Status = l.Status,
                DeadLine = l.DeadLine,
                ProjectID = l.ProjectID,
                TeamMemberID = l.TeamMemberID,
            };

            return View(taskViewModel);


        }
        [HttpPost]
        public async Task<IActionResult> EditTask(Tasks task , int id)
        {
            var tas = await db.tasks.FirstOrDefaultAsync(x => x.TasksID ==id);
            tas.Status = task.Status;
            tas.Description = task.Description;
            tas.Priority = task.Priority;
            tas.DeadLine = task.DeadLine;
            tas.ProjectID = task.ProjectID;
            tas.TeamMemberID = task.TeamMemberID;
            var project = await db.projects.FirstOrDefaultAsync(x => x.ProjectID == tas.ProjectID);
            db.tasks.Update( tas );
            await db.SaveChangesAsync();
            return RedirectToAction("GetProjects" , "Project"); 
        }
    }
}
