using Miameal.Models;

namespace Miameal.Services.Meals;

public interface IMealService
{
    void CreateMeal(Meal meal);

    Meal GetMeal(Guid id);
}