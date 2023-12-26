using Roomex.GeoCoordinate.Api.Domain.DistanceCalculator;
using Roomex.GeoCoordinate.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGeoCoordinatorService, GeoCoordinatorService>();
builder.Services.AddScoped<IDistanceCalculator, DistanceCalculatorFormula1>();
builder.Services.AddScoped<IInternalLocalizationService, InternalLocalizationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseRouting();
app.UseHttpsRedirection();

app.Run();

public partial class Program;