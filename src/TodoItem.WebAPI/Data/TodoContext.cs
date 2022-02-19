using Microsoft.EntityFrameworkCore;

namespace TodoItem.WebAPI.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Models.TodoItem> TodoItem { get; set; } = null!;
}
