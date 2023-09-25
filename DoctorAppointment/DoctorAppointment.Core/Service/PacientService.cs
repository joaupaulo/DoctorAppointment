using System;
using DoctorAppointment.Core.Interface;
using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Identity.Model;

namespace DoctorAppointment.Core;

public class PacientService : IPacientService
{
    public void ProcessPacient(PacientDto pacientDto)
    {
        Console.Clear();
        Console.WriteLine($"Olá seja bem vindo {pacientDto.Name}");
        Console.WriteLine("Obrigado por utilizar nossos serviços!");
        Console.WriteLine("Para marcação de consultas digite 1");
        Console.WriteLine("Para visualisar seu histórico de consultas digite 2");
        int opcaoMenu = int.Parse(Console.ReadLine());
        switch (opcaoMenu)
        {
            case 1 :
                string oi = "oi";
                break;
            case 2 :
                string du = "du";
                break;
        }

    }
}

