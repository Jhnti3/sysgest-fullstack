using Microsoft.AspNetCore.Mvc;
using SysGestFullstack.Data;
using SysGestFullstack.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SysGestFullstack.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList(); // Certifique-se de buscar a tabela correta
            return View("Index", tasks); // Garante que está chamando a view correta
        }


        public IActionResult Create()
        {
            return View("Create"); // Garante que está chamando a View correta
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.DataCriacao = DateTime.Now; // Define a data de criação ao salvar
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", task);
        }

        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();
            return View(task); // Retorna o modelo correto
        }


        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", task);
        }

        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();
            return View("Delete", task); // Garante que está chamando a View correta
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
