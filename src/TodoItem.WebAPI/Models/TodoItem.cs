using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoItem.WebAPI.Models;

public class TodoItemResponse
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}