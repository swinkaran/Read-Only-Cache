using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Azure.CachedStorage.Entities.Models
{
    public class ExpenseCategory
    {
        public ExpenseCategory()
        {
            Expenses = new List<Expense>();
        }

        [Key]
        [Column("ExpenseCategoryId")]
        public Guid ExpenseCategoryId { get; set; }
        
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(60, ErrorMessage = "Expense can't be longer than 60 characters")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be longer than 60 characters")]
        public string Descrption { get; set; }
        
        //Navigation properties
        public ICollection<Expense> Expenses { get; set; }
    }
}
