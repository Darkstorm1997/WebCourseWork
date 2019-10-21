using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecReview.Models;

namespace TecReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly TecReviewContext _context;
        private const int MAIN_ITEMS_NUM = 9;

        public HomeController(TecReviewContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Dictionary<Category, List<Item>> categories = new Dictionary<Category, List<Item>>();

            foreach (Category c in _context.Categories)
            {
                categories.Add(c, await GetFeatured(c).ToListAsync());
            }

            ViewData["Categories"] = await _context.Categories.ToListAsync();

            ViewData["MainItem"] = null;
            ViewData["Recent"] = null;

            
            if (_context.Items.Any())
            {
                var items = _context.Items.OrderBy(x => new Random().Next());

                var mainItems = await items.Take(MAIN_ITEMS_NUM).ToListAsync();

                ViewData["MainItems"] = mainItems;

                ViewData["Recent"] = await _context.Items.OrderByDescending(x => x.DateCreated).Take(3).ToListAsync();
            }

            return View();
        }

        public IQueryable<Item> GetFeatured(Category category)
        {
            return _context.Entry(category).Collection(p => p.Items).Query().Take(4);
        }
    }
}
