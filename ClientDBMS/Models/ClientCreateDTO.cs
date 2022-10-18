using System.ComponentModel.DataAnnotations;

namespace ClientDBMS.Models
{
    public class ClientCreateDTO
    {
        [Required(ErrorMessage ="Enter First Name")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Phonenumber")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
    }
}
