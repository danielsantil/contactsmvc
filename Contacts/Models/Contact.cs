using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class Contact : BaseModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }
    }
}
