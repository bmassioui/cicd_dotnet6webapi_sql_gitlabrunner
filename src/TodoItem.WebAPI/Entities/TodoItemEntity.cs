using System.ComponentModel.DataAnnotations.Schema;
using TodoItem.WebAPI.Entities.Common;

namespace TodoItem.WebAPI.Entities;

[Table("TodoItem")]
public class TodoItemEntity : BaseEntity
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}