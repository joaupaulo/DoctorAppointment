using DnsClient.Internal;
using DoctorApp.Interfaces;
using DoctorApp.Model;
using DoctorApp.Model.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DoctorApp.Service;

public class ProcessAppointment : IProcessAppointment
{
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _signInManager;
    public ProcessAppointment(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task InitializeProcessAppointment( )
    {
        UserDto userDto = new UserDto();
        Console.WriteLine("Olá, vamos dar inicio ao seu processo de cadastramento");

        while (true)
        {
            Console.WriteLine("Escolha uma das opções para darmos sequencia!");
            Console.WriteLine("1. Criar Conta");
            Console.WriteLine("2. Realizar Login");
            Console.WriteLine("3. Sair");

            int option = Int32.Parse(Console.ReadLine());

            switch (option)
            
            {
                case 1:
                    var user = await CreateUserAsync(userDto);
                    if (user != null)
                    {
                        Console.WriteLine("Usuário criado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível criar o usuário.");
                    }

                    break;
                case 2:
                    await LoginUserAsync(userDto );
                    break;
                case 3:
                    Console.WriteLine("Saindo da aplicação.");
                    return;
            }
        }

        async Task<ApplicationUser> CreateUserAsync(UserDto userDto)
        {
            try
            {
                Console.Write("Digite seu nome de usuário: ");
                var username = Console.ReadLine();

                Console.Write("Digite seu email: ");
                var email = Console.ReadLine();

                Console.WriteLine("Para sua segurança geramos sua senha do tipo HASH, enviamos para seu email!");
                var user = new ApplicationUser() { UserName = username, Email = email,SecurityStamp = Guid.NewGuid().ToString() };
                userDto.Password = "Joapaulo1234444!";
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("Erro ao criar o usuário:");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        async Task LoginUserAsync(UserDto userDto)
        {
            Console.Write("Digite seu nome de usuário para fazer login: ");
            var username = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            var password = Console.ReadLine();

            var result =
                await _signInManager.PasswordSignInAsync(username, password, isPersistent: false,
                    lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Console.WriteLine("Usuário autenticado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao autenticar o usuário. Verifique suas credenciais.");
            }
        }

        string GenerateRandomPassword()
        {
            return "Rapereggggea1277773!";
        }
    }
}