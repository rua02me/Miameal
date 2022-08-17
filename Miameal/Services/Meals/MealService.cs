using Miameal.Models;

namespace Miameal.Services.Meals;

public class MealService : IMealService
{
    private readonly Dictionary<Guid, Meal> _meals = new();

    public void CreateMeal(Meal meal)
    {
        _meals.Add(meal.Id, meal);
    }

    public Meal GetMeal(Guid id)
    {
        return _meals[id];
    }
}