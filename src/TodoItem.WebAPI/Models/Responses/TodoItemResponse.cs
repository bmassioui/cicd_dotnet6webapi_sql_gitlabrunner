﻿namespace TodoItem.WebAPI.Models.Responses;

public class TodoItemResponse
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}