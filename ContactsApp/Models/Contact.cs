using System;
using System.ComponentModel.DataAnnotations;
namespace ContactsApp.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "first name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "last name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "email address")]
        public string Email { get; set; }

        public Contact()
        {
        }

        public Contact(string FirstName, string LastName, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
        }
    }
}
