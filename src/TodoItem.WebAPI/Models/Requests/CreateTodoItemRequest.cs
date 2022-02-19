namespace TodoItem.WebAPI.Models.Requests;

public class CreateTodoItemRequest
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}