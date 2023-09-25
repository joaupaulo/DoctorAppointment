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
        
        foreach (TypeHealthPlan plan in Enum.GetValues(typeof(TypeHealthPlan)))
        {
            Console.WriteLine($"Digite {(int)plan} para selecionar o plano: {plan}");
            // Após selecionar o plano de saúde, faça a lógica para determinar especialidades e horários disponíveis.
        }

        int OptionPlanHealth = int.Parse(Console.ReadLine());

        FilterOptionPlanHealth(OptionPlanHealth, appointment);
    }

    private static void FilterOptionPlanHealth(int OptionPlanHealth, Appointment appointment )
    {
        if (OptionPlanHealth == (int)TypeHealthPlan.Bradesco)
        {
            appointment.TypeHealthPlan = TypeHealthPlan.Bradesco;
            Console.WriteLine("Plano Bradesco selecionado.");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.Planserv)
        {
            appointment.TypeHealthPlan = TypeHealthPlan.Planserv;
            Console.WriteLine("Plano Planserv selecionado.");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.Unimed)
        {
            appointment.TypeHealthPlan = TypeHealthPlan.Unimed;
            Console.WriteLine("Plano Unimed selecionado.");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.MultiVida)
        {
            Console.WriteLine(" Plano MultiVida Selecionado");
        }
    }
    public static void AvaliableMedicalSpeciality(Appointment appointment)
    {
       Console.Clear();

       if (appointment.TypeHealthPlan.Equals(TypeHealthPlan.Bradesco))
       {
           filterSpecialtyMedic(appointment);
       }
       
       else if (appointment.TypeHealthPlan.Equals(TypeHealthPlan.Planserv))
       {
           filterSpecialtyMedic(appointment);
       }
       
       else if (appointment.TypeHealthPlan.Equals(TypeHealthPlan.MultiVida))
       {
           filterSpecialtyMedic(appointment);
       }
    }

    private static void filterSpecialtyMedic(Appointment appointment)
    {
        foreach (MedicalSpecialty Specialty in Enum.GetValues(typeof(MedicalSpecialty)))
        {
            Console.WriteLine($"Digite {(int)Specialty} para selecionar a especialidade médica disponível: {Specialty}");
        }
        
        int option = Int32.Parse(Console.ReadLine());

        MedicalSpecialty specialty = (MedicalSpecialty)option;
        
        Console.WriteLine($"Especialidade médica{specialty} escolhida!");
        
        if (option == 1)
        {
            appointment.MedicalSpecialty = MedicalSpecialty.Cardiology;
        }
    }

    public static void RegisterNamePacientAppointment(Appointment appointment, PacientDto pacientDto)
    {
        Console.WriteLine($"Olá{pacientDto.Name},vamos preencher sua ficha!");
        appointment.NameOfPacient = pacientDto.Name;
    }
    
}