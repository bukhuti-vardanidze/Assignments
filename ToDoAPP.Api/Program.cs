using Microsoft.EntityFrameworkCore;
using ToDoAPP.Api.Auth;
using ToDoAPP.Api.Db;
using ToDoAPP.Api.Db.Entities;
using ToDoAPP.Api.Auth;
using ToDoAPP.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAuthService, AuthService>();
AuthConfigurator.Configure(builder);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<AppDbContext>(c =>
    c.UseSqlServer(builder.Configuration["AppDbContextConnection"]));

builder.Services.AddTransient<ISendEmailRequestRepository, SendEmailRequestRepository>();


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