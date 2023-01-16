using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Db.Models;

namespace ToDoApp.Api.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public DbSet<TodoEntity> Todos { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=todoapp_db;User Id=sa;Password=pass123;");

            var db = new AppDbContext(optionsBuilder.Options);

            db.Todos.Add(new TodoEntity
            {
                Id = 1,
                UserId = 1,
                StatusId = 1,
                Name = "person 1",
                Description = "project_1",
                Deadline = DateTime.Now

            });

            db.SaveChanges();
        }

       
    }
}
