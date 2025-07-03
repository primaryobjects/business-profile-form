using System.ComponentModel.DataAnnotations;
using Server.Attributes;

namespace Server.Types
{
    public class Contact
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? BusinessName { get; set; }
        [Required]
        public string? ContactName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Industry { get; set; }
        public string? BusinessSize { get; set; }
        [ValidValues("email", "phone", "nopreference", "")]
        public string? ContactMethod { get; set; }
        [ValidValues("consulting", "support", "training")]
        public List<string> Services { get; set; } = [];

        public Contact()
        {
        }
    }
}