﻿using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Model.Dtos;

public class UserDto
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