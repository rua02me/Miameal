using Miameal.Services.Meals;

var builder = WebApplication.CreateBuilder(args);

{
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IMealService, MealService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}

