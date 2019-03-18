using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Azure.CachedStorage.Entities.Models
{
    [Table("Profile")]
    public class Profile
    {
        public Profile()
        {
            Expenses = new List<Expense>();
        }

        [Key]
        [Column("ProfileId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(60, ErrorMessage = "First name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(60, ErrorMessage = "Last name can't be longer than 60 characters")]
        public string LastName { get; set; }

        public string Email { get; set; }

        List<Expense> Expenses { get; set; }
        //[StringLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        //public string Description { get; set; }

        //[Required(ErrorMessage = "Amount is required")]
        //public float Amount { get; set; }

        //[Required(ErrorMessage = "Date is required")]
        //public float Date { get; set; }
    }
}
