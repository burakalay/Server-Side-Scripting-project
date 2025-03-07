using System.ComponentModel.DataAnnotations;

namespace SecurePasswordApp.Models  // Namespace 
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public int Age { get; set; }
    }
}
