using Miameal.Contracts.Meal;
using Miameal.ServiceErrors;
using ErrorOr;

namespace Miameal.Models;

public class Meal
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;

    public Guid Id { get; }
    public string Name { get; }
    public string Descriptions { get;}
    public DateTime StartDateTime { get;}
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get;}

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

    public static ErrorOr<Meal> Create(
        string name,
        string descriptions,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null)

     {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Meal.InvalidName);
        }

        if (descriptions.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Meal.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Meal(
            id ?? Guid.NewGuid(),
            name,
            descriptions,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet);
    }

    public static ErrorOr<Meal> From(CreateMealRequest request)
    {
        return Create(
            request.Name,
            request.Descriptions,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet);
    }

    public static ErrorOr<Meal> From(Guid id, UpsertMealRequest request)
    {
        return Create(
            request.Name,
            request.Descriptions,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id);
    }

}