namespace TodoItem.WebAPI.Models.Requests;

public class UpdateTodoItemRequest
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public bool IsDeleted { get; set; }
}