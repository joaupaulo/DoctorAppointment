using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace DoctorAppointment.Identity.Model;
[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
    
}