using Assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entites;

namespace Assesment.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext db;

        public TeamMemberController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TeamMemberDetails(int id)
        {
            var mm = await db.teamMembers.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.TeamMemberID == id);
            return View(mm);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeamMember(int id)
        {
            var l = await GetMemberByID(id);
            return View(l);
        }
        [HttpPost]
        public async Task<IActionResult> EditTeamMember(TeamMember teamMember)
        {
            db.teamMembers.Update(teamMember);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProjects","Project");
        }
        public async Task<IActionResult> RemoveMember(int id)
        {
            var l = await GetMemberByID(id);
            db.teamMembers.Remove(l);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProjects", "Project");


        }
        public async Task<TeamMember> GetMemberByID(int id)
        {
            var l = await db.teamMembers.FirstOrDefaultAsync(x => x.TeamMemberID == id);
            return l;
        }

    }
}
