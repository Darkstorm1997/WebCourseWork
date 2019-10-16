﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsNow.Models;
using Newtonsoft.Json;

namespace NewsNow.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly NewsNowContext _context;

        public StatisticsController(NewsNowContext context)
        {
            _context = context;
        }

        // GET: Statistics
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Comments()
        {
            var monthlyComments = await _context.Comments.GroupBy(x => new { x.DatePosted.Year, x.DatePosted.Month }).ToListAsync();

            var statistics = monthlyComments.Select(monthGroup => new {
                month = monthGroup.First().DatePosted.Month.ToString() + '/' + monthGroup.First().DatePosted.Year.ToString(),
                comments = monthGroup.Count()
            }).ToList();

            return Json(statistics);
        }

        public async Task<IActionResult> Items()
        {
            var itemsPerCategory = await _context.Items.Join(_context.Categories,
                category => category.CategoryId,
                item => item.CategoryId,
                (item, category) => new Item()
                {
                    ItemId = item.ItemId,
                    CategoryId = category.CategoryId,
                    Category = category
                }).GroupBy(x => x.CategoryId).ToListAsync();

            var statistics = itemsPerCategory.Select(categoryItems => new
            {
                label = categoryItems.First().Category.Name,
                color = categoryItems.First().Category.HexColor,
                value = categoryItems.Count()
            }).ToList();

            return Json(statistics);
        }

        public async Task<IActionResult> Locations()
        {
            var locations = await _context.Items.Select(item => item.Location).ToListAsync();

            return Json(locations);
        }
    }
}
