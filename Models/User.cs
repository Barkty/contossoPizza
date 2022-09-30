using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Staff ID is required")]
    public string? StaffId { get; set; }

    [Required(ErrorMessage = "Please enter staff name")]
    public string? StaffName { get; set; }

    [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
    [RegularExpression(@"/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/", ErrorMessage = "A valid email is required")]
    public string? StaffEmail { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{7,}$/", ErrorMessage = "Password must contain 7 Characters, One Uppercase, One Lowercase and One Number")]
    public string? Password { get; set; }

    public string? Department { get; set;}

    public string? Gender { get; set;}

    public string? Avatar { get; set;}

    public UserRole Role { get; set; }

    public enum UserRole { ADMIN, USER }
}