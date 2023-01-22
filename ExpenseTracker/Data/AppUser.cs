using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public ICollection<Message> Messages { get; set; }

    }
}
