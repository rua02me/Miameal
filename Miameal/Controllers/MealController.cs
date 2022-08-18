using Miameal.Contracts.Meal;
using Miameal.Models;
using Miameal.ServiceErrors;
using Miameal.Services.Meals;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Miameal.Controllers;

public class MealsController : ApiController
{
    private readonly IMealService _mealService;

    public MealsController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpPost]
    public IActionResult CreateMeal(CreateMealRequest request)
    {
        ErrorOr<Meal> requestToMealResult = Meal.From(request);

        if (requestToMealResult.IsError)
        {
            return Problem(requestToMealResult.Errors);
        }

        var meal = requestToMealResult.Value;
        ErrorOr<Created> createMealResult = _mealService.CreateMeal(meal);

        return createMealResult.Match(
            created => CreatedAtGetMeal(meal),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMeal(Guid id)
    {
        ErrorOr<Meal> getMealResult = _mealService.GetMeal(id);

        return getMealResult.Match(
            meal => Ok(MapMealResponse(meal)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertMeal(Guid id, UpsertMealRequest request)
    {
        ErrorOr<Meal> requestToMealResult = Meal.From(id, request);

        if (requestToMealResult.IsError)
        {
            return Problem(requestToMealResult.Errors);
        }

        var meal = requestToMealResult.Value;
        ErrorOr<UpsertedMeal> upsertMealResult = _mealService.UpsertMeal(meal);

        return upsertMealResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetMeal(meal) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMeal(Guid id)
    {
        ErrorOr<Deleted> deleteMealResult = _mealService.DeleteMeal(id);

        return deleteMealResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static MealResponse MapMealResponse(Meal meal)
    {
        return new MealResponse(
            meal.Id,
            meal.Name,
            meal.Descriptions,
            meal.StartDateTime,
            meal.EndDateTime,
            meal.LastModifiedDateTime,
            meal.Savory,
            meal.Sweet);
    }

    private CreatedAtActionResult CreatedAtGetMeal(Meal meal)
    {
        return CreatedAtAction(
            actionName: nameof(GetMeal),
            routeValues: new { id = meal.Id },
            value: MapMealResponse(meal));
    }
}