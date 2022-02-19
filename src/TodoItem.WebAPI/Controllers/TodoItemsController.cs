using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoItem.WebAPI.Data;
using TodoItem.WebAPI.Entities;
using TodoItem.WebAPI.Models.Requests;
using TodoItem.WebAPI.Models.Responses;

namespace TodoItem.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly TodoContext _context;
    private readonly IMapper _mapper;

    public TodoItemsController(TodoContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    /// <summary>
    /// Get TodoItems
    /// </summary>
    /// <param name="includeDeleted?">If NULL or FALSE, the deleted TodoItems are excluded automatically</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadTodoItemResponse>>> GetTodoItem(bool? includeDeleted)
    {
        var todoItems = _context.TodoItem.AsQueryable();

        if (includeDeleted is null || !includeDeleted.Value) todoItems = todoItems.Where(todoItem => !todoItem.IsDeleted);

        return Ok(_mapper.Map<IEnumerable<ReadTodoItemResponse>>(await todoItems.ToListAsync()));
    }

    /// <summary>
    /// Get TodoItem by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReadTodoItemResponse>> GetTodoItem(long id)
    {
        var todoItem = await _context.TodoItem.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ReadTodoItemResponse>(todoItem));
    }

    /// <summary>
    /// Update an existing TodoItem
    /// </summary>
    /// <param name="id"></param>
    /// <param name="todoItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, UpdateTodoItemRequest todoItem)
    {
        if (id != todoItem.Id) return BadRequest();

        var todoItemToUpdate = await _context.TodoItem.FindAsync(id);

        if (todoItemToUpdate == null) return NotFound();

        _mapper.Map(todoItem, todoItemToUpdate);

        _context.Entry(todoItemToUpdate).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    /// <summary>
    /// Create TodoItem
    /// </summary>
    /// <param name="todoItem"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ReadTodoItemResponse>> PostTodoItem(CreateTodoItemRequest todoItem)
    {
        var todoItemToCreate = _mapper.Map<TodoItemEntity>(todoItem);
        _context.TodoItem.Add(todoItemToCreate);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodoItem", new { id = todoItemToCreate.Id }, todoItemToCreate);
    }

    /// <summary>
    /// Mark TodoItem as Soft deleted
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItemToDelete = await _context.TodoItem.FindAsync(id);

        if (todoItemToDelete == null) return NotFound();

        todoItemToDelete.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TodoItemExists(long id)
    {
        return _context.TodoItem.Any(e => e.Id == id);
    }
}
