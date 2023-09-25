using System;
using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Domain.Model;

namespace DoctorAppointment.Core;

public class RegisterAppointment
{

    public Appointment RegisterAppo(PacientDto pacientDto)
    {
        Appointment appointment = new();
        RegisterNamePacientAppointment(appointment,pacientDto);
        SelectHealthPlan(appointment, pacientDto);
        return appointment;
    }
    
    public static void SelectHealthPlan(Appointment appointment,PacientDto pacientDto)
    {
        Console.WriteLine($"Olá{appointment.NameOfPacient}, preciso que me diga o seu plano de saúde " +
                          $"para que eu possa verificar a disponibilidade das consultas");
        
        Console.WriteLine("Escolha seu plano de saúde");
        
        int count = 0;
        foreach (string name in Enum.GetNames(typeof(TypeHealthPlan)))
        {
            Console.WriteLine($"Digite {count} para selecionar o plano : {name}");
            count++;
 //Após selecionar o plano de saúde, fazemos a lógica para dizer quais especialidades temos direito e qual o horário disponivel
        }

        int OptionPlanHealth = int.Parse(Console.ReadLine());

        FilterOptionPlanHealth(OptionPlanHealth, appointment);
    }

    private static void FilterOptionPlanHealth(int OptionPlanHealth, Appointment appointment )
    {
        if (OptionPlanHealth == (int)TypeHealthPlan.Bradesco)
        {
            Console.WriteLine("Bradesco");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.Planserv)
        {
            Console.WriteLine("Planserv");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.Unimed)
        {
            Console.WriteLine("Unimed");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.MultiVida)
        {
            Console.WriteLine("MultiVida");
        }
    }

    public static void RegisterNamePacientAppointment(Appointment appointment, PacientDto pacientDto)
    {
        Console.WriteLine($"Olá{pacientDto.Name},vamos preencher sua ficha!");
        appointment.NameOfPacient = pacientDto.Name;
    }
    
}