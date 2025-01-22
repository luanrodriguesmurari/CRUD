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

        public async Task Create(TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            await _repository.Add(taskItem);
        }

        public async Task Update(int id, TaskItem updatedTaskItem)
        {
            var task = await _repository.GetById(id);
            if (task != null)
            {
                task.Name = updatedTaskItem.Name;
                task.Description = updatedTaskItem.Description;
                task.Completed = updatedTaskItem.Completed;

                await _repository.Update(task);
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
