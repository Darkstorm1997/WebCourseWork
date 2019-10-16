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
    public class SearchController : Controller
    {
        private readonly TecReviewContext _context;

        public SearchController(TecReviewContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = _context.Categories.ToList<Category>();
            return View();
        }
    }
}
