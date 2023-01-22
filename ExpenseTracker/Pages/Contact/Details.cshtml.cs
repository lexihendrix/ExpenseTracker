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
    public class DetailsModel : PageModel
    {
        private readonly ExpenseTracker.Data.ApplicationDbContext _context;

        public DetailsModel(ExpenseTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Message Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Message = await _context.Message.FirstOrDefaultAsync(m => m.Id == id);

            if (Message == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
