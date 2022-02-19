namespace TodoItem.WebAPI.Models.Requests;

public class UpdateTodoItemRequest
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}