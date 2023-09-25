using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DoctorAppointment.Core;
using DoctorAppointment.Core.Interface;
using DoctorAppointment.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace DoctorAppointment.Identity;

public class AccountController : Controller
{
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _signInManager;
    private IDoctorService _doctorService;
    private IPacientService _pacientService;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IDoctorService doctorService, IPacientService pacientService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _doctorService = doctorService;
        _pacientService = pacientService;
    }
    
    // GET
    public IActionResult Login()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Login([Required][EmailAddress] string email, [Required] string password, string returnurl)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser != null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(appUser, password,false,false);
                if (result.Succeeded)
                {
                    if (appUser.typeUser == TypeUser.Paciente)
                    {
                        
                        
                    }
                    else
                    {
                       DoctorService doctor = new();
                       doctor.ProcessDoctor();
                    }
                }
            }
            ModelState.AddModelError(nameof(email), "Login Failed");
        }

        return View();
    }
    
}