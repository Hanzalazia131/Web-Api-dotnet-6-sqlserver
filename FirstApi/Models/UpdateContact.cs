using System.ComponentModel.DataAnnotations;

namespace FirstApi.Models
{
    public class UpdateContact
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }        
        public string Phone { get; set; }      
    }
}
