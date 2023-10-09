namespace DoctorApp.Interfaces;

public interface IUserSecurityStampStore<ApplicationUser>
{
    Task SetSecurityStampAsync(ApplicationUser app);
}