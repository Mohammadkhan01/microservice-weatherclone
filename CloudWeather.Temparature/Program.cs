using CloudWeather.Temparature.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TempDbContext>(
    opts =>
    {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("Appdb"));
    }, ServiceLifetime.Transient
    );
var app = builder.Build();
app.MapGet("/observation/{zip}",async(string zip,[FromQuery] int? days, TempDbContext db) => {
    if (days == null || days<1 || days>30) return Results.BadRequest("not found");
    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var result = await db.Temparature.Where(precip => precip.ZipCode == zip && precip.CreatedOn > startDate).ToListAsync();
    return Results.Ok(result);
});

app.Run();