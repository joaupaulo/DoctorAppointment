using System;
using DoctorAppointment.Core.Interface;

namespace DoctorAppointment.Core;

public class DoctorService : IDoctorService
{
   private IDoctorService _doctorServiceImplementation;

   public void ProcessDoctor()
   {
      Console.WriteLine("Olá, seja bem vindo Doutor!");
   } 
}