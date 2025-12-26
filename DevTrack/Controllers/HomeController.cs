using Microsoft.EntityFrameworkCore;
using DevTrack.Data;
using DevTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                ProjectCount = await _db.Projects.CountAsync(),
                OpenTasks = await _db.Tasks.CountAsync(t => t.Status == DevTrack.Models.TaskStatus.Open),
                InProgressTasks = await _db.Tasks.CountAsync(t => t.Status == DevTrack.Models.TaskStatus.InProgress),
                DoneTasks = await _db.Tasks.CountAsync(t => t.Status == DevTrack.Models.TaskStatus.Done)
            };

            return View(model);
        }
    }
}
