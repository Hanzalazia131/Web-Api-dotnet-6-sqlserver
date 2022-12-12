using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FirstApi.Models
{
    public class AddContactRequest
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
