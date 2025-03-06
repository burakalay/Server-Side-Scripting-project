using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SecurePasswordApp.Models
{
    public class PasswordCredential
    {
        //PasswordCredentialId - primary key for Password Credential class
        public int PasswordCredentialId { get; set; }


        //WebsiteName - Field for users to enter the name of the website
        [Required(ErrorMessage = "Please enter the Website name")]
        [Display(Name = "Website Name")]
        public string WebsiteName { get; set; }


        //WebsiteUrl - Nullable field (users can decide to input website url or not)
        [Display(Name = "Website Link")]
        public string? WebsiteUrl { get; set; }


        //WebsiteUsername - Field for users to enter the username for each website they want to save to the application
        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Website Username")]
        public string WebsiteUsername { get; set; }


        //WebsitePassword - Field for users to enter the password for each website they want to save to the application
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Website Password")]
        public string WebsitePassword { get; set; }


        //DateCreated - Field to store the date each username and password was entered into the application
        public DateTime DateCreated { get; set; }


        //UserId - foreign key from parent table, User (to implement one-to-many relationship)
        public int UserId { get; set; }


        //Navigation property - parent reference (Each password credential has a user)
        public User User { get; set; }

    }
}
