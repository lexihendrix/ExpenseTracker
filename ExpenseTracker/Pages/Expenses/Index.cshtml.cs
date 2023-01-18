using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;

namespace ExpenseTracker.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly ExpenseTracker.Data.ApplicationDbContext _context;

        public IndexModel(ExpenseTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; }

        public async Task OnGetAsync()
        {
            Expense = await _context.Expenses
                .Include(e => e.Category).ToListAsync();
        }
    }
}
