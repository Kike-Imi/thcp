using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tchp.Data;
using tchp.Models;

namespace tchp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext db;
        public DepartmentsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index() 
        {
            return View(await db.Departments.ToListAsync());
        }

        //Crear por medio de vista
        public IActionResult Create() 
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department) 
        {
            if (ModelState.IsValid)
            {
                db.Add(department);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
    }
}
