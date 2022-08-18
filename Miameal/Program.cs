using Miameal.Services.Meals;

var builder = WebApplication.CreateBuilder(args);

{
// Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddScoped<IMealService, MealService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}

