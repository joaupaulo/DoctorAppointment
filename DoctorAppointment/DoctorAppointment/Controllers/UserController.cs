using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorAppointment.Core;
using DoctorAppointment.Core.Interface;
using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Domain.Model;
using DoctorAppointment.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.Identity
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private IDoctorService _doctorService;
        private IPacientService _pacientService;
        
        public UserController(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager,IDoctorService doctorService, IPacientService pacientService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _doctorService = doctorService;
            _pacientService = pacientService;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    typeUser = user.typeUser
                };

                IdentityResult result = await _userManager.CreateAsync(applicationUser, user.Password);

                if (result.Succeeded)
                {
                    if (applicationUser.typeUser == TypeUser.Paciente)
                    {
                        PacientDto pacientData = new();
                        pacientData.Name = applicationUser.UserName;
                        pacientData.Email = applicationUser.Email;
                        pacientData.Registerpacient = applicationUser.Id;
                        
                        _pacientService.ProcessPacient(pacientData);
                        
                    }
                    else
                    {
                        DoctorService doctor = new();
                        doctor.ProcessDoctor();
                    }
                    ViewBag.Message = "User Created Sucessfully";
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result =
                    await _roleManager.CreateAsync(new ApplicationRole() { Name = userRole.RoleName });
                if (result.Succeeded)
                {
                    
                    ViewBag.Message = "Role Created Sucessfully";
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }
        
        
        
    }
}