using GPA_Calculator.Db;
using GPA_Calculator.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["AppDbContextConnection"];
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connection));

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
