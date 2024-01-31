using Microsoft.EntityFrameworkCore;
using Campus02WebService.Models;

namespace Campus02WebService.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
        {
        }

        public DbSet<ToDoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; }
        public DbSet<Campus02WebService.Models.User> User { get; set; } = default!;
    }
}
