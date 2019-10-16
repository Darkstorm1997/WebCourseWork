using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecReview.Models;

namespace TecReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly TecReviewContext _context;

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

            ViewData["Categories"] = categories;

            ViewData["MainItem"] = null;
            ViewData["MainItemCategory"] = null;

            if (_context.Items.Any())
            {
                var mainItem = await _context.Items.FirstAsync();
                ViewData["MainItem"] = mainItem;
                ViewData["MainItemCategory"] = await _context.Categories
                    .FirstOrDefaultAsync(c => c.CategoryId == mainItem.CategoryId);
            }

            // TODO: Actually calculate the featured items
            ViewData["Items"] = await _context.Items.ToListAsync();
            ViewData["Featured"] = await _context.Items.Skip(1).Take(2).ToListAsync();
            ViewData["Recent"] = await _context.Items.OrderByDescending(x => x.DateCreated).Take(3).ToListAsync();

            return View();
        }

        public IQueryable<Item> GetFeatured(Category category)
        {
            return _context.Entry(category).Collection(p => p.Items).Query().Take(4);
        }
    }
}
