using System;
using DoctorAppointment.Core.Interface;

namespace DoctorAppointment.Core;

public class PacientService : IPacientService
{
    public void ProcessPacient()
    {
        Console.Clear();
        Console.WriteLine("Olá seja bem vindo");
        Console.WriteLine("Obrigado por utilizar nossos serviços!");
        Console.WriteLine("Para marcação de consultas escreva, Consulta");
        Console.WriteLine("Para visualisar seu histórico de consultas escreva, Histórico");

    }
}

