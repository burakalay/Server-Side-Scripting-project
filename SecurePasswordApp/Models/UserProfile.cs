using System.ComponentModel.DataAnnotations;

public class UserProfile
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    public int Age { get; set; }
}
