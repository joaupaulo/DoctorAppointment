using DoctorApp.Interfaces;
using DoctorApp.Model;
using DoctorApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoctorApp;

public class Program
{
   static void Main()
   {
       try
       {
           HostBuilder();

       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           throw;
       }
       
      

   }
   
   public static void HostBuilder()
   {
       try
       {
           IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
               {
                   services.AddLogging();
                   services.AddTransient<IProcessAppointment, ProcessAppointment>();
                   services.AddIdentity<ApplicationUser, ApplicationRole>()
                       .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
                       ("mongodb+srv://joaopaulo123:1799jp@cluster0.8rok3.mongodb.net/?authSource=admin",
                           "UserRegister").AddDefaultTokenProviders();
               })
               .Build();

           using (var scope = _host.Services.CreateScope())
           {
               var serviceProvider = scope.ServiceProvider;
               var processAppointment = serviceProvider.GetRequiredService<IProcessAppointment>();
               
               processAppointment
                   .InitializeProcessAppointment(); 
           }
       }
       catch (Exception ex)
       {
           Console.WriteLine(ex);
           throw;
       }
      
   }
}

public class CustomIdentityErrorDescriber
{
    public string Erorr { get; set; }
}
