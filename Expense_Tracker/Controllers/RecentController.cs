using Expense_Tracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Expense_Tracker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RecentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RecentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //Recent Transactions
            ViewBag.RecentTrasactions = await _context.Transactions
                .Include(i => i.Category)
                .OrderByDescending(j => j.Date)
                .Take(10)
                .ToListAsync();

            return View();
        }


    }
}
