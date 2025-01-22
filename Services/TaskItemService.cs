using AutoMapper;
using CRUD.Interfaces;
using CRUD.Models;

namespace CRUD.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        private readonly IMapper _mapper;

        public TaskItemService(ITaskItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TaskItem> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(TaskItemDto taskItem)
        {
            var task = _mapper.Map<TaskItem>(taskItem);
            await _repository.Add(task);
        }

        public async Task Update(int id, TaskItemDto taskItemDto)
        {
            var taskItem = await _repository.GetById(id);
            if (taskItem != null)
            {
                taskItem.Name = taskItemDto.Name ?? taskItem.Name;
                taskItem.Description = taskItemDto.Description ?? taskItem.Description;
                taskItem.Completed = taskItemDto.Completed ?? taskItem.Completed;

                var task = _mapper.Map<TaskItem>(taskItemDto);
                await _repository.Update(taskItem);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _repository.GetById(id);
            if (task == null)
                return false;

            await _repository.Delete(id);
            return true;
        }
    }
}
