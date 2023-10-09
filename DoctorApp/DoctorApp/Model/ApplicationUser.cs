using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace DoctorApp.Model;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
    public TypeUser typeUser { get; set; } 
}