using AutoMapper;
using TodoItem.WebAPI.Entities;
using TodoItem.WebAPI.Models.Requests;
using TodoItem.WebAPI.Models.Responses;

namespace TodoItem.WebAPI.Profiles;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        // TodoItem ===> TodoItemReponse
        CreateMap<TodoItemEntity, ReadTodoItemResponse>();

        // CreateTodoItemRequest ===> TodoItem
        CreateMap<CreateTodoItemRequest, TodoItemEntity>();

        // UpdateTodoItemRequest ===> TodoItem
        CreateMap<UpdateTodoItemRequest, TodoItemEntity>()
            .ForMember(x => x.CreatedAt, opt => opt.Ignore())
            .ForAllMembers(x => x.Condition(
            (src, dest, prop) =>
            {
                // ignore null & empty string properties
                if (prop == null) return false;
                if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                return true;
            }
        ));

    }
}
