using Microsoft.AspNetCore.Mvc;
using SysGestFullstack.Data;
using SysGestFullstack.Models;
using System.Linq;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using QuestPDF.Drawing;
using QuestPDF.Elements;

namespace SysGestFullstack.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm)
        {
            var users = _context.Users.Where(u => !u.IsDeleted).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                users = users.Where(u =>
                    u.Name.ToLower().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm)
                );
            }

            ViewData["SearchTerm"] = searchTerm;
            return View(users.ToList());
        }

        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsDeleted = false;
                _context.Users.Add(user);
                _context.SaveChanges();
                AddUserLog("Criado", user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.Find(user.Id);
                if (existingUser == null) return NotFound();

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                if (!string.IsNullOrEmpty(user.Password))
                {
                    existingUser.Password = user.Password;
                }

                _context.Users.Update(existingUser);
                _context.SaveChanges();
                AddUserLog("Editado", existingUser);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.IsDeleted = true;
            _context.Users.Update(user);
            _context.SaveChanges();
            AddUserLog("Excluído", user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportarExcel()
        {
            var usuarios = _context.Users.ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Usuários");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nome";
                worksheet.Cell(1, 3).Value = "Email";

                int linha = 2;
                foreach (var usuario in usuarios)
                {
                    worksheet.Cell(linha, 1).Value = usuario.Id;
                    worksheet.Cell(linha, 2).Value = usuario.Name;
                    worksheet.Cell(linha, 3).Value = usuario.Email;
                    linha++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Usuarios.xlsx");
                }
            }
        }

        public IActionResult ExportarPDF()
        {
            // Definir licença como Community
            QuestPDF.Settings.License = LicenseType.Community;

            var usuarios = _context.Users.ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Text("Lista de Usuários").FontSize(20).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(3);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderCellStyle).Text("ID");
                            header.Cell().Element(HeaderCellStyle).Text("Nome");
                            header.Cell().Element(HeaderCellStyle).Text("Email");
                        });

                        foreach (var user in usuarios)
                        {
                            table.Cell().Element(DataCellStyle).Text(user.Id.ToString());
                            table.Cell().Element(DataCellStyle).Text(user.Name);
                            table.Cell().Element(DataCellStyle).Text(user.Email);
                        }

                        static IContainer HeaderCellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold()).Padding(5).Background("#f0f0f0");
                        }

                        static IContainer DataCellStyle(IContainer container)
                        {
                            return container.BorderBottom(1).BorderColor("#e0e0e0").Padding(5);
                        }
                    });
                });
            });

            var stream = new MemoryStream();
            document.GeneratePdf(stream);
            stream.Position = 0;

            return File(stream.ToArray(), "application/pdf", "Usuarios.pdf");
        }


        private void AddUserLog(string action, User user)
        {
            var log = new UserLog
            {
                Action = action,
                UserName = user.Name,
                UserEmail = user.Email
            };

            _context.UserLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
