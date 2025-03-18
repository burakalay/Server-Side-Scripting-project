using System.ComponentModel.DataAnnotations;

namespace EncriptifyApp.Models
{
    public class UserDetail
    {
        //pk field
        public int UserDetailId { get; set; }


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

        //Navigation property - child reference (Each User has a list of password credentials)
        public List<PasswordCredential>? PasswordCredentials { get; set; }
    }
}
