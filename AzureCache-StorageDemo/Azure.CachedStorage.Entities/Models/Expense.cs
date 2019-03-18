using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Azure.CachedStorage.Entities.Models
{
    [Table("Expense")]
    public class Expense
    {
        [Key]
        [Column("ExpenseId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Expense is required")]
        [StringLength(60, ErrorMessage = "Expense can't be longer than 60 characters")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime BilledDate { get; set; }

        ////Profile
        //[Required]
        //public Profile Profile { get; set; }
        //[Required]
        //public long ProfileId { get; set; }

        // Expenses Category
        [Required]
        public ExpenseCategory ExpenseCategory { get; set; }
        [Required]
        public Guid ExpenseCategoryId { get; set; }

    }
}
