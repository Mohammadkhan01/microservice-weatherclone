using CloudWeather.Report.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WeatherReportDbContext>(
    opts =>
    {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("Appdb"));
    }, ServiceLifetime.Transient
    );
var app = builder.Build();
app.MapGet("/observation/{zip}",async(string zip,[FromQuery] int? days, WeatherReportDbContext db) => {
    if (days == null || days<1 || days>30) return Results.BadRequest("not found");
    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var result = await db.Reports.Where(precip => precip.ZipCode == zip && precip.CreatedOn > startDate).ToListAsync();
    return Results.Ok(result);
});

app.Run();
