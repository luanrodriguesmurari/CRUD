using AutoMapper;
using CRUD.Models;

namespace CRUD.Mappings
{
    public class TaskItemMappingProfile : Profile
    {
        public TaskItemMappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        }
    }
}
