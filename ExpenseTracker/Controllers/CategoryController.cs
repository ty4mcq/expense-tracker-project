using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return _context.Categories != null ?
                View(await _context.Categories.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Categories' is null.");
        }
        
        // GET: Category/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Category());
            else
                return View(_context.Categories.Find(id));
        }

        // POST: Category/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CategoryId,Title,Icon,Type")] Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.CategoryId == 0)
                    _context.Add(category);
                else
                    _context.Update(category);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}