using ExpenseTracker.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Data
{
    public class Category
    {
        [Key]
        [Column("CategoryID")]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}

