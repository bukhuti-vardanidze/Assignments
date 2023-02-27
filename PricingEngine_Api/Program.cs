using Microsoft.EntityFrameworkCore;
using PricingEngine_Api.Db;
using PricingEngine_Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["AppDbContextConnection"];
builder.Services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICalculationRepository, CalculationRepository>();
builder.Services.AddTransient<IDataBaseInputRepository, DataBaseInputRepository>();
builder.Services.AddTransient<IUserInputRepository, UserInputRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
