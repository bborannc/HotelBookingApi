using FluentValidation;
using FluentValidation.AspNetCore;
using HotelBookingApi.Data.Context;
using HotelBookingApi.Service.Mapping;
using HotelBookingApi.Service.Services;
using HotelBookingApi.Service.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper Entegrasyonu
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// FluentValidation Entegrasyonu
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ReservationCreateDtoValidator>();

// Business Services (DI Kaydı)
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<ReservationService>();

var app = builder.Build();

// Pipeline Yapılandırması
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
