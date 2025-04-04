using Microsoft.AspNetCore.Mvc;
using sysgest_fullstack.Models; // Referência aos modelos
using SysGestFullstack.Data; // Referência ao contexto do banco
using SysGestFullstack.Models;
using System.Linq;

namespace sysgest_fullstack.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // Ação principal que renderiza o painel de administração
        public IActionResult Index()
        {
            var dashboardData = new DashboardViewModel
            {
                TotalUsers = _context.Users.Count(), // Conta o total de usuários no banco
                ActiveUsers = _context.Users.Where(u => u.IsActive).Count(), // Conta os usuários ativos
                RecentActivities = _context.Activities.OrderByDescending(a => a.Date).Take(5).ToList() // Pega as 5 últimas atividades
            };

            // Se a view estiver em /Views/Admin/Dashboard.cshtml, use esse código
            return View("Dashboard", dashboardData);
        }
    }
}

