namespace Miameal.Contracts.Meal;

public record MealResponse(
    Guid Id,
    string Name,
    string Descriptions,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet);