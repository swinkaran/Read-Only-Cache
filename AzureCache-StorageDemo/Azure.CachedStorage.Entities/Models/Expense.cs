using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Azure.CachedStorage.Entities.Models
{
    [Table("Expense")]
    public class Expense : IEntity
    {
        [Key]
        [Column("ExpenseId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Expense is required")]
        [StringLength(60, ErrorMessage = "Expense can't be longer than 60 characters")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public float Date { get; set; }
    }
}
