using System;
using DoctorAppointment.Core.Interface;
using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Identity.Model;

namespace DoctorAppointment.Core;

public class PacientService : IPacientService
{
    private IRegisterAppointment _IRegisterAppointment;

    public PacientService(IRegisterAppointment IRegisterAppointment)
    {
        _IRegisterAppointment = IRegisterAppointment;
    }
    public void ProcessPacient(PacientDto pacientDto)
    {
        Console.WriteLine($"Olá seja bem vindo {pacientDto.Name}");
        Console.WriteLine("Obrigado por utilizar nossos serviços!");
        Console.WriteLine("Para marcação de consultas digite 1");
        Console.WriteLine("Para visualisar seu histórico de consultas digite 2");
        Program oii = new();
        oii.Teste(); 
        
        int opcaoMenu = int.Parse(Console.ReadLine());
        switch (opcaoMenu)
        {
                
            case 1 :
                Program oi = new();
                oi.Teste();
                break;
            case 2 :
                string du = "du";
                break;
        }

    }
}

