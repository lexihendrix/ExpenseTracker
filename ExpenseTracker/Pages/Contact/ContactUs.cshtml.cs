using ExpenseTracker.Data;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Pages.Contact
{
    public class ContactUsModel : PageModel
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly ApplicationDbContext _context;

        public ContactUsModel(ApplicationDbContext context, IEmailSenderService emailSenderService)
        {
            _context = context;
            _emailSenderService = emailSenderService;
        }

        //[BindProperty]
        //public Message Message { get; set; }
      
        public void OnGet()
        {
        }
        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Message.Add(Message);
            Message.CreatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        */
        public void OnPost()
        {
            
            if (ModelState.IsValid)
            {
                _emailSenderService.EmailFromCustomer(Namn,Header,Message,Email);
                //Anropa Namn, header, Message
                Sent = true;
            }
            
        }

        //testing create separate class + entity/relation
        public bool Sent { get; set; }
        [BindProperty]
        public string Namn { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Header { get; set; }
        [BindProperty]
        public string Message { get; set; }
    }
}
