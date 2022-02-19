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


    // GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadTodoItemResponse>>> GetTodoItem()
    {
        return Ok(_mapper.Map<IEnumerable<ReadTodoItemResponse>>(await _context.TodoItem.ToListAsync()));
    }

    // GET: api/TodoItems/5
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

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, UpdateTodoItemRequest todoItem)
    {
        if (id != todoItem.Id) return BadRequest();

        var todoItemToUpdate = _mapper.Map<TodoItemEntity>(todoItem);
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

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ReadTodoItemResponse>> PostTodoItem(CreateTodoItemRequest todoItem)
    {
        var todoItemToCreate = _mapper.Map<TodoItemEntity>(todoItem);
        _context.TodoItem.Add(todoItemToCreate);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodoItem", new { id = todoItemToCreate.Id }, todoItemToCreate);
    }

    // DELETE: api/TodoItems/5
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
