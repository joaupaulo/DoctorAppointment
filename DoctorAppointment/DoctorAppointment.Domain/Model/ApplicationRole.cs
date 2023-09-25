using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace DoctorAppointment.Domain.Model;
[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
    
}