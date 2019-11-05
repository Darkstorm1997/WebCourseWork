using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecReview.Models;

namespace TecReview.Controllers
{
    public class ItemsController : Controller
    {
        private readonly TecReviewContext _context;
        private readonly IHostingEnvironment _env;

        private readonly string _itemsTransitionDataPath;

        public ItemsController(TecReviewContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;

            // If working in Visual Studio, make sure the 'Copy to Output Directory'
            // property of the file is set to 'Copy always'
            _itemsTransitionDataPath = System.IO.Path.Combine(_env.WebRootPath, "ml", "items-transition-data.txt");
        }

        [Authorize]
        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.Include(a => a.Category).FirstOrDefaultAsync(m => m.ItemId == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public async Task<IActionResult> MoveRelated(int? prevId, int? newId)
        {
            if (prevId == null || newId == null)
            {
                return NotFound();
            }
            
            string line = ((float) prevId).ToString("0.0") + ',' + ((float) newId).ToString("0.0");
            System.IO.File.AppendAllText(_itemsTransitionDataPath, line + Environment.NewLine);

            return RedirectToAction(nameof(Details), new {id = newId });
        }

        public async Task<IActionResult> Comments(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.Where(c => c.ItemId == id.Value).ToListAsync();

            if (comments == null)
            {
                return NotFound();
            }

            return Json(comments);
        }

        public async Task<IActionResult> Search(int? category, string header, string summary, DateTime? date)
        {
            var result = _context.Items.AsQueryable();

            if (category != null)
                result = result.Where(x => x.CategoryId == category);
            if (!String.IsNullOrWhiteSpace(header))
                result = result.Where(x => x.Header.Contains(header));
            if (!String.IsNullOrWhiteSpace(summary))
                result = result.Where(x => x.Summary.Contains(summary));
            if (date.HasValue)
                result = result.Where(x => x.DateCreated.Value.Date == date.Value.Date);

            return Json(result);
        }

        public async Task<IActionResult> GetRelatedItems(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            const int NUM_OF_RELATED_ITEMS = 3;
            var relatedItems = new List<Item>();

            try
            {
                int mlRelatedItem = MachineLearning.GetRelatedItem(_itemsTransitionDataPath, id.Value);

                if (mlRelatedItem != id.Value)
                {
                    var item = await _context.Items.FirstAsync(c => c.ItemId == mlRelatedItem);

                    if (item != null)
                    {
                        relatedItems.Add(item);

                        // Try to find a related item to the related item
                        int mlRelatedToRelatedItem = MachineLearning.GetRelatedItem(_itemsTransitionDataPath, mlRelatedItem);

                        if (mlRelatedToRelatedItem != mlRelatedItem && mlRelatedToRelatedItem != id.Value)
                        {
                            item = await _context.Items.FirstAsync(c => c.ItemId == mlRelatedToRelatedItem);

                            if (item != null)
                            {
                                relatedItems.Add(item);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
            }

            int itemsCount = _context.Items.Count();
            Random random = new Random();

            // Fill the rest of the related items with random items, in order to
            // have the option for diversity (and by that make better predictions in the future)
            while (relatedItems.Count() < NUM_OF_RELATED_ITEMS)
            {
                int randomItemId = random.Next(1, itemsCount);

                if (randomItemId != id.Value && !relatedItems.Exists(c => c.ItemId == randomItemId))
                {
                    var randomItem = await _context.Items.FirstAsync(c => c.ItemId == randomItemId);

                    if (randomItem != null)
                    {
                        relatedItems.Add(randomItem);
                    }
                }
            }

            return Json(relatedItems);
        }

        // GET: Items/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Header,Summary,Content,HomeImageUrl,CategoryId,Location,IsShowMap")] Item itemModel)
        {
            if (ModelState.IsValid)
            {
                itemModel.DateCreated = DateTime.Now;
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");

            return View(itemModel);
        }

        // GET: Items/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");

            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Header,Summary,Content,HomeImageUrl,CategoryId,Location,IsShowMap")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Items.Attach(item);
                    _context.Entry(item).Property(x => x.Content).IsModified = true;
                    _context.Entry(item).Property(x => x.Header).IsModified = true;
                    _context.Entry(item).Property(x => x.Summary).IsModified = true;
                    _context.Entry(item).Property(x => x.HomeImageUrl).IsModified = true;
                    _context.Entry(item).Property(x => x.CategoryId).IsModified = true;
                    _context.Entry(item).Property(x => x.Location).IsModified = true;
                    _context.Entry(item).Property(x => x.IsShowMap).IsModified = true;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");

            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
