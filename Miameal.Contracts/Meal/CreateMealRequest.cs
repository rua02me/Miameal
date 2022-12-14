namespace Miameal.Contracts.Meal;

public record CreateMealRequest(
    string Name,
    string Descriptions,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);

