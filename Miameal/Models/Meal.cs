namespace Miameal.Models;

public class Meal
{
    public Guid Id { get; set;}
    public string Name { get; set;}
    public string Descriptions { get; set;}
    public DateTime StartDateTime { get; set;}
    public DateTime EndDateTime { get; set;}
    public DateTime LastModifiedDateTime { get; set;}
    public List<string> Savory { get;set; }
    public List<string> Sweet { get;set; }

    public Meal(
        Guid id,
        string name,
        string descriptions,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {
        Id = id;
        Name = name;
        Descriptions = descriptions;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }

}