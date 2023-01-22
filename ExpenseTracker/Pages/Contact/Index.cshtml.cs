using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTracker.Pages.Contact
{
    [Authorize]

    public class IndexModel : PageModel
    {
        private readonly ExpenseTracker.Data.ApplicationDbContext _context;

        public IndexModel(ExpenseTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Message> Message { get;set; }

        public async Task OnGetAsync()
        {
            Message = await _context.Message.ToListAsync();
        }
    }
}
