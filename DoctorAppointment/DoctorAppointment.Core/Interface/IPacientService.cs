using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Identity.Model;

namespace DoctorAppointment.Core.Interface;

public interface IPacientService
{
    public void ProcessPacient(PacientDto pacientDto);
}