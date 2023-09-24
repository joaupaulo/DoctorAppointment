namespace DoctorAppointment.Identity.Model;

public class MongoDbConfig
{
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
    public string ConnectionString { get; set; }
}