using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ExpenseTracker.Data;
public class DataInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;


    public DataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public void SeedData()
    {
        _context.Database.Migrate();
        SeedCategories();
        SeedExpenses();
        SeedRoles();
        SeedUsers();
    }

    private void SeedCategories()
    {
        AddCategoryIfNotExists("Home");
        AddCategoryIfNotExists("Uncategorized");
        AddCategoryIfNotExists("Food");
        AddCategoryIfNotExists("Loans");
        AddCategoryIfNotExists("Shopping");
        AddCategoryIfNotExists("Transportation");
        AddCategoryIfNotExists("Leisure");
    }

    private void AddCategoryIfNotExists(string name)
    {
        if (_context.Categories.Any(c => c.Name == name)) return;
        _context.Categories.Add(new Category
        {
            Name = name,
        });
        _context.SaveChanges();
    }

    private void SeedExpenses()
    {
        AddExpenseIfNotExists("Rent", 7160, DateTime.Now.AddDays(-1),"Home");
    }

    private void AddExpenseIfNotExists(string name, decimal amount, DateTime date, string catName)
    {
        if (_context.Expenses.Any()) return;
        var category = _context.Categories.First(e => e.Name == catName);
        _context.Expenses.Add(new Expense
        {
            Name = name,
            Amount= amount,
            Date = date,
            Category = category
        });
        _context.SaveChanges();
    }

    private void SeedUsers()
    {
        AddUserIfNotExists("lexi.hendrix@expensetracker.se", "Hejsan123#", new string[] { "Admin" });
        AddUserIfNotExists("lexi.hendrix@awesome.com", "Hejsan123#", new string[] { "User", "Subscriber" });
    }



    private void AddUserIfNotExists(string userName, string password, string[] roles)
    {
        if (_userManager.FindByEmailAsync(userName).Result != null) return;

        var user = new IdentityUser
        {
            UserName = userName,
            Email = userName,
            EmailConfirmed = true
        };
        var result = _userManager.CreateAsync(user, password).Result;
        var r = _userManager.AddToRolesAsync(user, roles).Result;
        _context.SaveChanges();
    }

    private void SeedRoles()
    {
        var role = _context.Roles.FirstOrDefault(r => r.Name == "Admin");
        if (role == null)
        {
            _context.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
        }
        role = _context.Roles.FirstOrDefault(r => r.Name == "User");
        if (role == null)
        {
            _context.Roles.Add(new IdentityRole { Name = "User", NormalizedName = "User" });
        }
        role = _context.Roles.FirstOrDefault(r => r.Name == "Subscriber");
        if (role == null)
        {
            _context.Roles.Add(new IdentityRole { Name = "Subscriber", NormalizedName = "Subscriber" });
        }
        _context.SaveChanges();

    }
}