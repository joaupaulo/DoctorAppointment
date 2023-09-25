using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Driver;
using MongoDbGenericRepository.Attributes;

namespace DoctorAppointment.Identity.Model;
[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
   public TypeUser typeUser { get; set; } 
}