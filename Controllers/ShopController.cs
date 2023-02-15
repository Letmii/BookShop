using BookShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    public class ShopController : Controller
    {

        private readonly BookShopContext _context;

        public ShopController(BookShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Books != null ?
                        View(await _context.Books.ToListAsync()) :
                        Problem("Entity set 'BookShopContext.Book'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
