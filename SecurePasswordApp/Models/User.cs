using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
namespace SecurePasswordApp.Models
{
    public class User
    {
        //pk field
        public int UserId { get; set; }


        //FirstName - field to identify a user's first name
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }


        //LastName - field to identify a user's last name
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }


        //Email - field to identify a user's email address
        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [MaxLength(100)]
        public string Email { get; set; }


        //Username - field to store a user's username to sign in to the application
        [Required(ErrorMessage = "Username is required. Please enter a username between 8 and 30 characters")]
        [Display(Name = "Username")]
        [MinLength(8), MaxLength(30)]
        public string Username { get; set; }


        //Username - field to store a user's password to sign in to the application
        [Required(ErrorMessage = "Password is required. Please enter a valid password between 8 and 25 characters")]
        [Display(Name = "Password")]
        [MinLength(8), MaxLength(25)]
        public string Password { get; set; }


        //Navigation property - child reference (Each User has a list of password credentials)
        public List<PasswordCredential> PasswordCredentials { get; set; }

    }
}
