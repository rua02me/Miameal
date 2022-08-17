using Microsoft.AspNetCore.Mvc;
using Miameal.Contracts.Meal;
using Miameal.Models;
using Miameal.Services.Meals;

namespace Miameal.Controllers;

[ApiController]
[Route("/miameals")]

public class MealController : ControllerBase 
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpPost()]
    public IActionResult CreateMeal(CreateMealRequest request)
    {
        var meal = new Meal(
            Guid.NewGuid(),
            request.Name,
            request.Descriptions,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _mealService.CreateMeal(meal);

        var response = new MealResponse(
            meal.Id,
            meal.Name,
            meal.Descriptions,
            meal.StartDateTime,
            meal.EndDateTime,
            meal.LastModifiedDateTime,
            meal.Savory,
            meal.Sweet
        );

        return CreatedAtAction(
            actionName: nameof(GetMeal),
            new { id = meal.Id},
            value : response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMeal(Guid id)
    {
        Meal meal = _mealService.GetMeal(id);

        var response = new MealResponse(
            meal.Id,
            meal.Name,
            meal.Descriptions,
            meal.StartDateTime,
            meal.EndDateTime,
            meal.LastModifiedDateTime,
            meal.Savory,
            meal.Sweet);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsterMeal(Guid id, UpsterMealRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMeal(Guid id)
    {
        return Ok(id);
    }
}