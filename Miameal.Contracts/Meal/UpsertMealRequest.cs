namespace Miameal.Contracts.Meal;

public record UpsertMealRequest(
    string Name,
    string Descriptions,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);