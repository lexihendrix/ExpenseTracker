using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Data
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }
        [Required]
        [Display(Name = "Header")]
        public string Header { get; set; }
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Body { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Sent")]
        public DateTime? SentAt { get; set; }
        public bool Sent { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
