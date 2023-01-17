using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Auth;
using ToDoApp.Api.Db;
using ToDoApp.Api.Db.Models;
using ToDoAPP.Api.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAuthService, AuthService>();
AuthConfigurator.Configure(builder);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


////ent
//var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//optionsBuilder.UseSqlServer("Server=localhost;Database=todoapp_db;User Id=sa;Password=pass123;");

//var db = new AppDbContext(optionsBuilder.Options);

//db.Todos.Add(new TodoEntity
//{
//    Id = 1,
//    UserId = 1,
//    StatusId = 1,
//    Name = "person 1",
//    Description = "project_1",
//    Deadline = DateTime.Now

//});

//ent



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