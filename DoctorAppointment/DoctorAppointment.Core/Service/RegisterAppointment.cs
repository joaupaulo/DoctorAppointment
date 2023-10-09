using System;
using System.Collections.Generic;
using DoctorAppointment.Core.Interface;
using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Domain.Model;

namespace DoctorAppointment.Core;

public class RegisterAppointment : IRegisterAppointment
{

    public Appointment RegisterAppo(PacientDto pacientDto)
    {
        Appointment appointment = new();
        RegisterNamePacientAppointment(appointment,pacientDto);
        SelectHealthPlan(appointment, pacientDto);
        return appointment;
    }

    public static void SelectTypePayment(Appointment appointment)
    {
        foreach (TypePayment planPayment in Enum.GetValues(typeof(TypePayment)))
        {
            Console.WriteLine($"Digite {(int)planPayment} para selecionar o plano: {planPayment}");
        }
       
        int option = Int32.Parse(Console.ReadLine());

        appointment.TypePayment = (TypePayment)option;
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
        appointment.MedicalSpecialty = (TypeHealthPlan)OptionPlanHealth;
        FilterOptionPlanHealth(OptionPlanHealth, appointment);
    }

    private static void FilterOptionPlanHealth(int OptionPlanHealth, Appointment appointment )
    {
        if (OptionPlanHealth == (int)TypeHealthPlan.Bradesco)
        {
            Console.WriteLine("OK");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.Planserv)
        {
            Console.WriteLine("OK");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.Unimed)
        {
            
            Console.WriteLine("oK");
        }
        else if (OptionPlanHealth == (int)TypeHealthPlan.MultiVida)
        {
            Console.WriteLine("OK");
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
        
        if (option == 2)
        {
            appointment.MedicalSpecialty = MedicalSpecialty.Dermatology;
        }
        
        if (option == 3)
        {
            appointment.MedicalSpecialty = MedicalSpecialty.Orthopedics;
        }
        
        if (option == 4)
        {
            appointment.MedicalSpecialty = MedicalSpecialty.Neurology;
        }
    }

    public static void RegisterNamePacientAppointment(Appointment appointment, PacientDto pacientDto)
    {
        Console.WriteLine($"Olá{pacientDto.Name},vamos preencher sua ficha!");
        appointment.NameOfPacient = pacientDto.Name;
    }

    public static void DateTimeAvaliable(Appointment appointment)
    {
        List<DateTime> datesAndTimes = new List<DateTime>
        {
            new DateTime(2023, 9, 25, 10, 0, 0),  
            new DateTime(2023, 9, 26, 14, 30, 0), 
            new DateTime(2023, 9, 27, 16, 15, 0), 
            new DateTime(2023, 9, 28, 11, 45, 0), 
            new DateTime(2023, 9, 29, 19, 0, 0)   
        };
        
        Console.WriteLine("Escolha um dos horários abaixo:");

        for (int i = 0; i < datesAndTimes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {datesAndTimes[i].ToString("dd/MM/yyyy HH:mm")}");
        }
        
        Console.Write("Digite o número correspondente ao horário desejado: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= datesAndTimes.Count)
        {
            DateTime selectedDateTime = datesAndTimes[choice - 1];
            Console.WriteLine($"Você escolheu o horário: {selectedDateTime.ToString("dd/MM/yyyy HH:mm")}");
            appointment.DateAppointment = selectedDateTime;
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }
}