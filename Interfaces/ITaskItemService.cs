using CRUD.Models;

namespace CRUD.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetAll();
        Task<TaskItem> GetById(int id);
        Task Create(TaskItemDto taskItemdto);
        Task Update(int id, TaskItem updatedTaskItem);
        Task<bool> Delete(int id);
    }
}
