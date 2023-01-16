using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Db.Models;

namespace ToDoApp.Api.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TodoEntity> Todos { get; set; }
    }
}
