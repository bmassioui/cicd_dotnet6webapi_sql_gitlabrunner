using Microsoft.EntityFrameworkCore;
using TodoItem.WebAPI.Models.Responses;

namespace TodoItem.WebAPI.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItemResponse> TodoItem { get; set; } = null!;
}
