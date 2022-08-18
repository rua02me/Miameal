using Miameal.Models;
using ErrorOr;

namespace Miameal.Services.Meals;

public interface IMealService
{
    ErrorOr<Created> CreateMeal(Meal meal);
    ErrorOr<UpsertedMeal> UpsertMeal(Meal meal);
    ErrorOr<Meal> GetMeal(Guid id);
    ErrorOr<Deleted> DeleteMeal(Guid id);
}