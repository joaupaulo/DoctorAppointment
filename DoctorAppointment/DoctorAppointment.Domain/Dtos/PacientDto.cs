using System;

namespace DoctorAppointment.Domain.Dtos;

public class PacientDto
{
  public string Name { get; set; }  
  public string Email { get; set; }
  public Guid Registerpacient { get; set; }
}