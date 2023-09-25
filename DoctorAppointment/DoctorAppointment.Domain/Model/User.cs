using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Identity.Model;

public class User
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public TypeUser typeUser { get; set; }
}