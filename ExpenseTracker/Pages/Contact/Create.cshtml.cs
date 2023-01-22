using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTracker.Data;
using ExpenseTracker.Services;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Pages.Contact
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ExpenseTracker.Data.ApplicationDbContext _context;
        private readonly IEmailSenderService _emailSenderService;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(ExpenseTracker.Data.ApplicationDbContext context, IEmailSenderService emailSender, UserManager<AppUser> userManager)
        {
            _context = context;
            _emailSenderService = emailSender;
            _userManager = userManager;
        }
        /*
        public IActionResult OnGet()
        {
            Success = false;
            return Page();
        }
        */
        [BindProperty]
        public Message Message { get; set; }

        [BindProperty]
        public bool Success { get; set; }
        public IList<Message> Messages { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public void OnPost()
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }
            */

            //var name = User.FirstName + " " + User.LastName;
            var name = "pingu";
            var email = User.FindFirstValue(ClaimTypes.Email);
            _emailSenderService.EmailFromCustomer(name, Message.Header, Message.Body, email);
            Message.CreatedAt = DateTime.Now;
            Message.SentAt = DateTime.Now;
            Message.Sent = true;
            _context.Message.Add(Message);
            _context.SaveChanges();
            Success = true;

        }


        public IActionResult OnGet()
        {

            Success = false;
            Messages = _context.Message.ToList();
            return Page();

        }
    }
}
