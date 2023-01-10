using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideItemController : Controller
    {
        private AppDbContext _context;

        public SlideItemController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.SlideItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SlideItem item)
        {
            if (!ModelState.IsValid) return View(item);
            await  _context.SlideItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(item));
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}

