using System;

namespace DoctorAppointment.Core;

class Program
{
    static void Main()
    {
     
       

            Console.WriteLine("Este é o console do projeto de serviço.");

            Console.WriteLine("Digite um comando:");
            string input = Console.ReadLine();
            Console.WriteLine($"Comando digitado: {input}");
            Teste funcionaemnomedejesus = new Teste();
            funcionaemnomedejesus.ProcessDoctor();

        
    }
    public void Teste()
    {
        Main();
    }
}