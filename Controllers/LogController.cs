using Microsoft.AspNetCore.Mvc;
using SysGestFullstack.Data;
using System.Linq;

namespace SysGestFullstack.Controllers
{
    public class LogController : Controller
    {
        private readonly AppDbContext _context;

        public LogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Logs() // Alterado de Index para Logs
        {
            var logs = _context.UserLogs.OrderByDescending(l => l.Timestamp).ToList();
            return View(logs);
        }
    }
}
