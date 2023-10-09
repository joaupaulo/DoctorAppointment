using DoctorAppointment.Domain.Dtos;
using DoctorAppointment.Domain.Model;

namespace DoctorAppointment.Core.Interface;

public interface IRegisterAppointment
{
    public Appointment RegisterAppo(PacientDto pacientDto);

}