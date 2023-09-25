using System;

namespace DoctorAppointment.Domain.Model;

public class Appointment
{
   public string NameOfPacient {get; set;} 
   public string RegisterPacient { get; set; }
   public DateTime DateAppointment { get; set; }
   public Enum TypePayment { get; set; }
   public Enum TypeHealthPlan { get; set; }
   public Enum MedicalSpecialty { get; set; }
}